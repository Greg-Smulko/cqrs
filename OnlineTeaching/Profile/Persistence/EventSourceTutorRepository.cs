using OnlineTeaching;
using OnlineTeaching.DataStore;
using Profile.Domain;
using Profile.Domain.Models;

namespace Profile.Persistence
{
    public class EventSourceTutorRepository : EventSourceRepository, TutorRepository
    {
        private readonly EventJournal _eventJournal;
        public EventSourceTutorRepository()
        {
            _eventJournal = EventJournal.Open("TalkWithMe-Tutor");
        }

        public Tutor TutorOf(Id id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Tutor tutor)
        {
            throw new System.NotImplementedException();
        }
    }
}