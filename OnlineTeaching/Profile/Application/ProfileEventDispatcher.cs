using OnlineTeaching.Messaging;

namespace Profile.Application
{
    public class ProfileEventDispatcher : EventDispatcher
    {
        private Topic topic;
        private MessageBus messageBus;
        public ProfileEventDispatcher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
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