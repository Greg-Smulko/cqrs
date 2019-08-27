using OnlineTeaching;
using OnlineTeaching.DataStore;
using Profile.Domain;
using Profile.Domain.Models;

namespace Profile.Persistence
{
    public class EventSourceTutorRecommendationRepository : EventSourceRepository, TutorRecommendationRepository
    {
        private readonly EventJournal _eventJournal;
        public EventSourceTutorRecommendationRepository()
        {
            _eventJournal = EventJournal.Open("TalkWithMe-Profile");
        }

        public TutorRecommendation RecommendationFor(Id proposalId)
        {
            throw new System.NotImplementedException();
        }

        public void Save(TutorRecommendation recommendation)
        {
            var events = ToStoreEvents(recommendation.ProposalId.Value, recommendation.Events);
            _eventJournal.Write(events);
        }
    }
}
