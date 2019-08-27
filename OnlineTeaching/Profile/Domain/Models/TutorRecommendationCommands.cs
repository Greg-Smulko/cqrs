using System;
using System.Collections.Generic;
using System.Linq;
using OnlineTeaching;
using Profile.Projection;

namespace Profile.Domain.Models
{
    public class TutorRecommendationCommands
    {
        private readonly TutorRecommendationRepository _tutorRecommendationRepository;
        private readonly TutorProjection _tutorProjection;

        public TutorRecommendationCommands(TutorRecommendationRepository tutorRecommendationRepository, TutorProjection tutorProjection)
        {
            _tutorRecommendationRepository = tutorRecommendationRepository ?? throw new ArgumentNullException(nameof(tutorRecommendationRepository));
            _tutorProjection = tutorProjection ?? throw new ArgumentNullException(nameof(tutorProjection));
        }

        public void RecommendTutors(Id proposalId, string language, IEnumerable<DayOfWeek> scheduleOfTheWeek)
        {
            var daysOfWeek = scheduleOfTheWeek.ToList();
            var tutor = _tutorProjection.Get(language, daysOfWeek);
            var tutorRecommendation = TutorRecommendation.For(proposalId, language, daysOfWeek);
            tutorRecommendation.Recommend(Id.FromExisting(tutor.Id));

            _tutorRecommendationRepository.Save(tutorRecommendation);
        }
    }
}
