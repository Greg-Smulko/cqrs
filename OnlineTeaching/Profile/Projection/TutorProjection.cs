using System;
using System.Collections.Generic;
using System.Linq;
using Profile.Domain.Models;

namespace Profile.Projection
{
    public class TutorProjection
    {
        private static List<TutorReadModel> Tutors = new List<TutorReadModel>
        {
            new TutorReadModel(Guid.NewGuid().ToString(), new List<LanguageQualification> {new LanguageQualification("English", Level.Native), new LanguageQualification("French", Level.Advanced)},
                new List<DayOfWeek>
                    {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday}),
            new TutorReadModel(Guid.NewGuid().ToString(), new List<LanguageQualification> { new LanguageQualification("German", Level.Basic), new LanguageQualification("French", Level.Native)},
                new List<DayOfWeek>
                    {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Saturday}),
            new TutorReadModel(Guid.NewGuid().ToString(), new List<LanguageQualification> {new LanguageQualification("Spanish", Level.Native)},
                new List<DayOfWeek> {DayOfWeek.Tuesday, DayOfWeek.Wednesday}),
            new TutorReadModel(Guid.NewGuid().ToString(), new List<LanguageQualification> {new LanguageQualification("Chinese", Level.Native), new LanguageQualification("Cantonese", Level.Native)},
                new List<DayOfWeek> {DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Friday})
        };

        public TutorReadModel Get(string language, IEnumerable<DayOfWeek> availability)
        {
            return Tutors.FirstOrDefault(t =>
                t.Languages.Any(l => l.Language == language) &&
                availability.All(t.Availability.Contains));
        }
    }

    public class TutorReadModel
    {
        public TutorReadModel(string id, List<LanguageQualification> languages, List<DayOfWeek> availability)
        {
            Id = id;
            Languages = languages;
            Availability = availability;
        }

        public string Id { get; }
        public List<LanguageQualification> Languages { get; }
        public List<DayOfWeek> Availability { get; }
    }
}
