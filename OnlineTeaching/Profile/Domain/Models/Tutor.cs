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

        public static Tutor Register()
        {
            return new Tutor(Id.Unique());
        }

        private Tutor(Id id)
        {
            Id = id;
            Languages = new List<LanguageQualification>();
            Availability = new Dictionary<DayOfWeek, List<TimeSpan>>();
        }
    }
}
