using System;
using System.Collections.Generic;
using Matching.Domain.Models;
using OnlineTeaching;

namespace Matching.Domain
{
    public class ProposalCommands
    {
        private readonly ProposalRepository _repository;

        public ProposalCommands(ProposalRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public void Submit(string studentId, string summary, string description, string language,
            DateTime startDate, DateTime? endDate, Dictionary<DayOfWeek, TimeSpan> scheduleOfTheWeek)
        {
            var proposal = Proposal.SubmitFor(new Student(studentId),
                Expectations.Of(summary, description, language,
                    LessonSchedule.With(startDate, endDate, scheduleOfTheWeek)));
            _repository.Save(proposal);
        }

        public void AssignTutor(string proposalId, string tutorId)
        {
            var proposal = _repository.ProposalOf(Id.FromExisting(proposalId));
            proposal.AssignTutor(new Tutor(tutorId));
            _repository.Save(proposal);
        }

        public void Accept(string proposalId)
        {
            var proposal = _repository.ProposalOf(Id.FromExisting(proposalId));
            proposal.Accept();
            _repository.Save(proposal);
        }

        public void Decline(string proposalId)
        {
            var proposal = _repository.ProposalOf(Id.FromExisting(proposalId));
            proposal.Decline();
            _repository.Save(proposal);
        }
    }
}
