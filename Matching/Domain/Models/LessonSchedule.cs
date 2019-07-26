using System;
using System.Collections.Generic;

namespace Matching.Domain.Models
{
    // Value object
    public sealed class LessonSchedule
    {
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public Dictionary<DayOfWeek, TimeSpan> ScheduleOfTheWeek { get; }

        public static LessonSchedule With(DateTime startDate, DateTime? endDate,
            Dictionary<DayOfWeek, TimeSpan> scheduleOfTheWeek)
        {
            return new LessonSchedule(startDate, endDate, scheduleOfTheWeek);
        }

        private LessonSchedule(DateTime startDate, DateTime? endDate,
            Dictionary<DayOfWeek, TimeSpan> scheduleOfTheWeek)
        {
            StartDate = startDate;
            EndDate = endDate;
            ScheduleOfTheWeek = scheduleOfTheWeek;
        }
    }
}