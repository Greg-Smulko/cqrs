namespace Matching.Domain.Models
{
    // Value object
    public sealed class Expectations
    {
        public string Summary { get; }
        public string Description { get; }
        public string Language { get; }
        public LessonSchedule Schedule { get; }

        public static Expectations Of(string summary, string description, string language, LessonSchedule schedule)
        {
            return new Expectations(summary, description, language, schedule);                
        }

        private Expectations(string summary, string description, string language, LessonSchedule schedule)
        {
            Summary = summary;
            Description = description;
            Language = language;
            Schedule = schedule;
        }
    }
}