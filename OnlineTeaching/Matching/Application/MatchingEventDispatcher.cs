using OnlineTeaching.Messaging;

namespace Matching.Application
{
    public class MatchingEventDispatcher : EventDispatcher
    {
        private Topic topic;
        private MessageBus messageBus;
        public MatchingEventDispatcher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
        {
            messageBus = MessageBus.Start(messageBusName);
            topic = messageBus.OpenTopic(topicName);
        }

        public override void Close()
        {
            topic.Close();
            messageBus.Close();
        }
    }
}
