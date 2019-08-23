using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTeaching.DataStore
{
    public class EventJournal
    {
        private static readonly Dictionary<string, EventJournal> EventJournals = new Dictionary<string, EventJournal>();
        public static EventJournal Open(string name)
        {
            if (!EventJournals.TryGetValue(name, out var journal))
            {
                journal = new EventJournal(name);
                EventJournals.Add(name, journal);
            }
            return journal;
        }

        public void Close()
        {
            EventJournals.Remove(Name);
        }

        private string Name { get; }
        private ConcurrentBag<EventEntity> Store { get; }
        private EventJournal(string name)
        {
            Name = name;
            Store = new ConcurrentBag<EventEntity>();
        }

        public void Write(IEnumerable<EventEntity> events)
        {
            foreach(var e in events)
            {
                Store.Add(e);
            }
        }

        public IEnumerable<EventEntity> Read(string identifier)
        {
            return Store.Where(e => e.Identifier == identifier);
        }

        public bool TryReadNext(out EventEntity storeEvent)
        {
            return Store.TryTake(out storeEvent);
        }
    }
}
