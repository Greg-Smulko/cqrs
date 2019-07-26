using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTeaching.DataStore
{
    public class EventJournal
    {
        private static readonly Dictionary<string, EventJournal> _eventJournals = new Dictionary<string, EventJournal>();
        public static EventJournal Open(string name)
        {
            if (!_eventJournals.TryGetValue(name, out var journal))
            {
                journal = new EventJournal(name);
                _eventJournals.Add(name, journal);
            }
            return journal;
        }

        public void Close()
        {
            _eventJournals.Remove(Name);
        }

        public string Name { get; }
        private ConcurrentBag<EventEntity> _store { get; }
        private EventJournal(string name)
        {
            Name = name;
            _store = new ConcurrentBag<EventEntity>();
        }

        public void Write(IEnumerable<EventEntity> events)
        {
            foreach(var e in events)
            {
                _store.Add(e);
            }
        }

        public IEnumerable<EventEntity> Read(string identifier)
        {
            return _store.Where(e => e.Identifier == identifier);
        }
    }
}
