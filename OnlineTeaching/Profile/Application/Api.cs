using Profile.Domain.Models;
using Profile.Persistence;
using Profile.Projection;

namespace Profile.Application
{
    public static class Api
    {
        public static TutorRecommendationCommands TutorRecommendationCommands =>
            new TutorRecommendationCommands(new EventSourceTutorRecommendationRepository(), new TutorProjection());
    }
}
