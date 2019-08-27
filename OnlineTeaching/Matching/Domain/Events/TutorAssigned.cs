using OnlineTeaching;

namespace Matching.Domain.Events
{
    public sealed class TutorAssigned : DomainEvent
    {
        public string ProposalId { get; }
        public string StudentId { get; }
        public string TutorId { get; }

        public TutorAssigned(string proposalId, string studentId, string tutorId)
        {
            ProposalId = proposalId;
            StudentId = studentId;
            TutorId = tutorId;
        }
    }
}