using OnlineTeaching;

namespace Profile.Domain.Events
{
    public class TutorRecommended : DomainEvent
    {
        public TutorRecommended(string proposalId, string tutorId)
        {
            ProposalId = proposalId;
            TutorId = tutorId;
        }

        public string ProposalId { get; }
        public string TutorId { get; }
    }
}
