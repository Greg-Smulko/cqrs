using System;
using System.Collections.Generic;
using System.Text;
using OnlineTeaching;

namespace Profile.Domain.Models
{
    public class TutorRecommendation : Aggregate
    {
        public string ProposalId { get; }
        public string Summary { get; }
        public string Description { get; }
        public string Language { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public Dictionary<DayOfWeek, TimeSpan> ScheduleOfTheWeek { get; }
        public List<string> Tutors { get; }

    }
}
