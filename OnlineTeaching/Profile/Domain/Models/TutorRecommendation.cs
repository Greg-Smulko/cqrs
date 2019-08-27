using System;
using System.Collections.Generic;
using System.Linq;
using OnlineTeaching;
using Profile.Domain.Events;

namespace Profile.Domain.Models
{
    public class TutorRecommendation : Aggregate
    {
        public Id ProposalId { get; }
        public string Language { get; }
        public IEnumerable<DayOfWeek> ScheduleOfTheWeek { get; }
        public Id Tutor { get; private set; }

        public static TutorRecommendation For(Id proposalId, string language,
            IEnumerable<DayOfWeek> scheduleOfTheWeek)
        {
            return new TutorRecommendation(proposalId, language, scheduleOfTheWeek);
        }

        private TutorRecommendation(Id proposalId, string language, IEnumerable<DayOfWeek> scheduleOfTheWeek)
        {
            ProposalId = proposalId;
            Language = language;
            ScheduleOfTheWeek = scheduleOfTheWeek;
        }

        public void Recommend(Id tutorId)
        {
            if (Tutor == null)
            {
                Apply(new TutorRecommended(ProposalId.Value, tutorId.Value));
            }
        }

        public void When(TutorRecommended tutorRecommended)
        {
            Tutor = Id.FromExisting(tutorRecommended.TutorId);
        }
    }
}
