using System.Collections.Concurrent;

namespace OnlineTeaching.Messaging
{
    public class MessageBus
    {
        private static readonly ConcurrentDictionary<string, MessageBus> MessageBuses = new ConcurrentDictionary<string, MessageBus>();

        public static MessageBus Start(string name)
        {
            if (!MessageBuses.TryGetValue(name, out var bus))
            {
                bus = new MessageBus(name);
                MessageBuses.TryAdd(name, bus);
            }

            return bus;
        }

        private string Name { get; }
        private readonly ConcurrentDictionary<string, Topic> _topics;
        private MessageBus(string name)
        {
            Name = name;
            _topics = new ConcurrentDictionary<string, Topic>();
        }

        public void Close()
        {
            if (MessageBuses.TryRemove(Name, out var bus))
            {
                foreach (var topic in _topics.Values)
                {
                    topic.Close();
                }
            }
        }

        public Topic OpenTopic(string name)
        {
            if (!_topics.TryGetValue(name, out var topic))
            {
                topic = new Topic(name);
                _topics.TryAdd(name, topic);
            }

            return topic;
        }
    }
}