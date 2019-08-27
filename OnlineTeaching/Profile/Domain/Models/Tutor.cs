using System;
using System.Collections.Generic;
using OnlineTeaching;

namespace Profile.Domain.Models
{
    public sealed class Tutor : Aggregate
    {
        public Id Id { get; }
        public List<LanguageQualification> Languages { get; }
        public Dictionary<DayOfWeek, List<TimeSpan>> Availability { get; }

        public static Tutor With(List<LanguageQualification> languages, Dictionary<DayOfWeek, List<TimeSpan>> availability)
        {
            return new Tutor(Id.Unique(), languages, availability);
        }

        private Tutor(Id id, List<LanguageQualification> languages, Dictionary<DayOfWeek, List<TimeSpan>> availability)
        {
            Id = id;
            Languages = languages;
            Availability = availability;
        }
    }
}
