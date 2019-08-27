using OnlineTeaching.Messaging;

namespace Profile.Application
{
    public class ProfileEventDispatcher : EventDispatcher
    {
        private readonly Topic _topic;
        private readonly MessageBus _messageBus;
        public ProfileEventDispatcher(string journalName, string messageBusName, string topicName) : base(journalName, messageBusName, topicName)
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