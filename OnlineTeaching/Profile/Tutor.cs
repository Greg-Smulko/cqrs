using System;
using System.Collections.Generic;
using OnlineTeaching;

namespace Profile
{
    public sealed class Tutor : Aggregate
    {
        public Id Id { get; }
        public List<string> Languages { get; }
        public Dictionary<DayOfWeek, List<TimeSpan>> Availability { get; }

        public static Tutor With(List<string> languages, Dictionary<DayOfWeek, List<TimeSpan>> availability)
        {
            return new Tutor(Id.Unique(), languages, availability);
        }

        private Tutor(Id id, List<string> languages, Dictionary<DayOfWeek, List<TimeSpan>> availability)
        {
            Id = id;
            Languages = languages;
            Availability = availability;
        }
    }
}
