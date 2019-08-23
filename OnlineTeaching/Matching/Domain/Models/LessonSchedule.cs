using System;
using System.Collections.Generic;

namespace Matching.Domain.Models
{
    // Value object
    public sealed class LessonSchedule
    {
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public List<DayOfWeek> Schedule { get; }

        public static LessonSchedule With(DateTime startDate, DateTime? endDate,
            List<DayOfWeek> schedule)
        {
            return new LessonSchedule(startDate, endDate, schedule);
        }

        private LessonSchedule(DateTime startDate, DateTime? endDate,
            List<DayOfWeek> schedule)
        {
            StartDate = startDate;
            EndDate = endDate;
            Schedule = schedule;
        }
    }
}