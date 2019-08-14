using OnlineTeaching.Messaging;

namespace Profile.Application
{
    public class ProfileEventJournalPublisher : EventJournalPublisher
    {
        private Topic topic;
        private MessageBus messageBus;
        public ProfileEventJournalPublisher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
        {
            messageBus = MessageBus.Start(messageBusName);
            topic = messageBus.OpenTopic("all");
        }

        public override void Close()
        {
            topic.Close();
            messageBus.Close();
        }
    }
}