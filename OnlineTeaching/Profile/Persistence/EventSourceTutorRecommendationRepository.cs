using OnlineTeaching;
using OnlineTeaching.DataStore;
using Profile.Domain;
using Profile.Domain.Models;

namespace Matching.Persistence
{
    public class EventSourceTutorRecommendationRepository : EventSourceRepository, TutorRepository
    {
        private readonly EventJournal _eventJournal;
        public EventSourceTutorRecommendationRepository()
        {
            _eventJournal = EventJournal.Open("TalkWithMe-Profile");
        }

        public Tutor TutorOf(Id id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Tutor proposal)
        {
            throw new System.NotImplementedException();
        }
    }
}
