using System;
using System.Collections.Generic;
using OnlineTeaching;

namespace Profile
{
    public sealed class Tutor : Aggregate
    {
        public Id Id { get; }

        public static Tutor With(List<string> languages, Dictionary<DayOfWeek, List<TimeSpan>> availability)
        {

        }

        private Tutor()
        {
            
        }
    }
}
