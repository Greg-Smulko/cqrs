namespace Profile.Domain.Models
{
    public class LanguageQualification
    {
        public LanguageQualification(string language, Level level)
        {
            Language = language;
            Level = level;
        }

        public string Language { get; }
        public Level Level { get; }
    }
}