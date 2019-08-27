using System;
using Newtonsoft.Json;
using OnlineTeaching.Messaging;

namespace Matching.Application
{
    public class ProfileTopicSubscriber : ISubscriber
    {
        public void Handle(Message message)
        {
            Console.WriteLine(message.Type);
            if (message.Type.StartsWith("Profile.Domain.Events.TutorRecommended"))
            {
                var deserialisedMessage = JsonConvert.DeserializeObject<TutorsRecommendedMessage>(message.Payload);
                Api.ProposalCommands.AssignTutor(deserialisedMessage.ProposalId, deserialisedMessage.TutorId);
            }
        }

        public ProfileTopicSubscriber()
        {
            var messageBus = MessageBus.Start("TalkWithMe");
            var profileTopic = messageBus.OpenTopic("Profile");
            profileTopic.Subscribe(this);
        }
    }

    public class TutorsRecommendedMessage
    {
        public TutorsRecommendedMessage(string proposalId, string tutorId)
        {
            ProposalId = proposalId;
            TutorId = tutorId;
        }

        public string ProposalId { get; }
        public string TutorId { get; }
    }
}
