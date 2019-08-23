using OnlineTeaching;
using Profile.Domain.Models;

namespace Profile.Domain
{
    public interface TutorRecommendationRepository
    {
        TutorRecommendation RecommendationFor(Id proposalId);
        void Save(TutorRecommendation recommendation);
    }
}