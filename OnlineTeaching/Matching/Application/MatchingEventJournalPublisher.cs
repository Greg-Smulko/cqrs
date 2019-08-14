using OnlineTeaching.Messaging;

namespace Matching.Application
{
    public class MatchingEventJournalPublisher : EventJournalPublisher
    {
        private Topic topic;
        private MessageBus messageBus;
        public MatchingEventJournalPublisher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
        {
            messageBus = MessageBus.Start(messageBusName);
            topic = messageBus.OpenTopic("matching");
        }

        public override void Close()
        {
            topic.Close();
            messageBus.Close();
        }
    }
}
