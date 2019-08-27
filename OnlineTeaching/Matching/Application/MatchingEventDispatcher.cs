using OnlineTeaching.Messaging;

namespace Matching.Application
{
    public class MatchingEventDispatcher : EventDispatcher
    {
        private readonly Topic _topic;
        private readonly MessageBus _messageBus;
        public MatchingEventDispatcher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
        {
            _messageBus = MessageBus.Start(messageBusName);
            _topic = _messageBus.OpenTopic(topicName);
        }

        public override void Close()
        {
            _topic.Close();
            _messageBus.Close();
        }
    }
}
