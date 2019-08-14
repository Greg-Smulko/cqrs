using OnlineTeaching.Messaging;

namespace Matching.Application
{
    public class ProfileTopicSubscriber : ISubscriber
    {
        public void Handle(Message message)
        {
            switch (message.Type)
            {
            }
        }

        public ProfileTopicSubscriber()
        {
            var messageBus = MessageBus.Start("TalkWithMe");
            var profileTopic = messageBus.OpenTopic("profile");
            profileTopic.Subscribe(this);
        }
    }
}
