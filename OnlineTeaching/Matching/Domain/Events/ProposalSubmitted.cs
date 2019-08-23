using System;
using System.Collections.Generic;
using Matching.Domain.Models;
using OnlineTeaching;

namespace Matching.Domain.Events
{
    public class ProposalSubmitted : DomainEvent
    {
        public string ProposalId { get; }
        public string StudentId { get; }
        public string Summary { get; }
        public string Description { get; }
        public string Language { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public List<DayOfWeek> Schedule { get; }

        public ProposalSubmitted(string proposalId, string studentId, Expectations expectations)
        {
            ProposalId = proposalId;
            StudentId = studentId;
            Summary = expectations.Summary;
            Description = expectations.Description;
            Language = expectations.Language;
            StartDate = expectations.Schedule.StartDate;
            EndDate = expectations.Schedule.EndDate;
            Schedule = expectations.Schedule.Schedule;
        }
    }
}