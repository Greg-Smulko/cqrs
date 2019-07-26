using System.Collections.Generic;
using Matching.Domain.Events;
using OnlineTeaching;

namespace Matching.Domain.Models
{
    public sealed class Proposal : Aggregate
    {
        public Id Id { get; private set; }
        public Student Student { get; private set; }
        public Tutor Tutor { get; private set; }
        public Expectations Expectations { get; private set; }
        public ProposalProgress Progress { get; private set; }
        public static Proposal SubmitFor(Student student, Expectations expectations)
        {
            return new Proposal(student, expectations);
        }

        private Proposal(Student student, Expectations expectations)
        {
            Apply(new ProposalSubmitted(Id.Value, student.Id.Value, expectations));
        }

        public Proposal(IEnumerable<DomainEvent> events): base(events) { }

        public void AssignTutor(Tutor tutor)
        {
            Apply(new TutorAssigned(Id.Value, Student.Id.Value, tutor.Id.Value));
        }

        public void Accept()
        {
            Apply(new ProposalAccepted(Id.Value, Student.Id.Value, Tutor.Id.Value, Expectations));
        }

        public void Decline()
        {
            Apply(new ProposalDeclined(Id.Value, Student.Id.Value,Tutor.Id.Value));
        }

        public void When(ProposalSubmitted proposalSubmitted)
        {
            Id = Id.Unique();
            Student = new Student(proposalSubmitted.StudentId);
            Expectations = Expectations.Of(proposalSubmitted.Summary, proposalSubmitted.Description,
                proposalSubmitted.Language,
                LessonSchedule.With(proposalSubmitted.StartDate, proposalSubmitted.EndDate,
                    proposalSubmitted.ScheduleOfTheWeek));
            Progress = ProposalProgress.Submitted;
        }

        public void When(TutorAssigned tutorAssigned)
        {
            if (Progress == ProposalProgress.Submitted)
            {
                Tutor = new Tutor(tutorAssigned.TutorId);
            }
        }

        public void When(ProposalAccepted proposalAccepted)
        {
            if (Progress == ProposalProgress.TutorAssigned)
            {
                Progress = ProposalProgress.Accepted;
            }
        }

        public void When(ProposalDeclined proposalDeclined)
        {
            if (Progress == ProposalProgress.TutorAssigned)
            {
                Progress = ProposalProgress.Declined;
            }
        }
    }
}