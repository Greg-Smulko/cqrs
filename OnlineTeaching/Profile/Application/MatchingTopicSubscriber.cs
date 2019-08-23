using System;
using OnlineTeaching.Messaging;

namespace Profile.Application
{
    public class MatchingTopicSubscriber : ISubscriber
    {
        public void Handle(Message message)
        {
            Console.WriteLine(message.Type);
            switch (message.Type)
            {
                case "Matching.Domain.Events.ProposalSubmitted":
                    //TODO recommend tutors
                    break;
            }
        }

        public MatchingTopicSubscriber()
        {
            var messageBus = MessageBus.Start("TalkWithMe");
            var topic = messageBus.OpenTopic("Matching");
            topic.Subscribe(this);
        }
    }
}
