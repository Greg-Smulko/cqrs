using System;
using System.Collections.Generic;

namespace Matching.Domain.Models
{
    // Value object
    public sealed class LessonSchedule
    {
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public List<DayOfWeek> ScheduleOfTheWeek { get; }

        public static LessonSchedule With(DateTime startDate, DateTime? endDate,
            List<DayOfWeek> schedule)
        {
            return new LessonSchedule(startDate, endDate, schedule);
        }

        private LessonSchedule(DateTime startDate, DateTime? endDate,
            List<DayOfWeek> scheduleOfTheWeek)
        {
            StartDate = startDate;
            EndDate = endDate;
            ScheduleOfTheWeek = scheduleOfTheWeek;
        }
    }
}