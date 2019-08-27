using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OnlineTeaching;
using OnlineTeaching.Messaging;

namespace Profile.Application
{
    public class MatchingTopicSubscriber : ISubscriber
    {
        private readonly MessageBus _messageBus;
        private readonly Topic _topic;

        public void Handle(Message message)
        {
            Console.WriteLine(message.Type);
            if (message.Type.StartsWith("Matching.Domain.Events.ProposalSubmitted"))
            {
                var deserializedMessage = JsonConvert.DeserializeObject<ProposalSubmittedMessage>(message.Payload);
                Api.TutorRecommendationCommands.RecommendTutors(Id.FromExisting(deserializedMessage.ProposalId), deserializedMessage.Language, deserializedMessage.Schedule);
            }
        }

        public MatchingTopicSubscriber()
        {
            _messageBus = MessageBus.Start("TalkWithMe");
            _topic = _messageBus.OpenTopic("Matching");
            _topic.Subscribe(this);
        }
    }

    public class ProposalSubmittedMessage
    {
        public ProposalSubmittedMessage(string proposalId, string language, List<DayOfWeek> schedule)
        {
            ProposalId = proposalId;
            Language = language;
            Schedule = schedule;
        }

        public string ProposalId { get; }
        public string Language { get; }
        public List<DayOfWeek> Schedule { get; }
    }
}
