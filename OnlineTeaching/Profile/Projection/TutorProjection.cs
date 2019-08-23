using System;
using System.Collections.Generic;

namespace Profile.Projection
{
    public class TutorProjection
    {
        private static List<TutorReadModel> Tutors = new List<TutorReadModel>
        {
            new TutorReadModel("123", new List<string> {"English", "French"},
                new List<DayOfWeek>
                    {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday}),
            new TutorReadModel("124", new List<string> {"German", "French"},
                new List<DayOfWeek>
                    {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Saturday}),
            new TutorReadModel("125", new List<string> {"Spanish"},
                new List<DayOfWeek> {DayOfWeek.Tuesday, DayOfWeek.Wednesday})
        };
    }

    public class TutorReadModel
    {
        public TutorReadModel(string id, List<string> languages, List<DayOfWeek> availability)
        {
            Id = id;
            Languages = languages;
            Availability = availability;
        }

        public string Id { get; }
        public List<string> Languages { get; }
        public List<DayOfWeek> Availability { get; }
    }
}
