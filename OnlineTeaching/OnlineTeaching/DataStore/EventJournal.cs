using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineTeaching.DataStore
{
    public class EventJournalReader
    {
        private readonly string _readName;
        private readonly EventJournal _journal;

        public EventJournalReader(string readName, EventJournal journal)
        {
            _readName = readName ?? throw new ArgumentNullException(nameof(readName));
            _journal = journal ?? throw new ArgumentNullException(nameof(journal));
        }
    }

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
        private List<EventEntity> Store { get; }
        private readonly object _lock = new object();
        

        //Hack for journal readers
        private int _index = 0;
        

        private EventJournal(string name)
        {
            Name = name;
            Store = new List<EventEntity>();
        }

        public void Write(IEnumerable<EventEntity> events)
        {
            lock (_lock)
            {
                Store.AddRange(events);
            }
        }

        public IEnumerable<EventEntity> Read(string identifier)
        {
            return Store.Where(e => e.Identifier == identifier);
        }

        public EventEntity ReadNext()
        {
            lock (_lock)
            {
                return _index >= Store.Count ? null : Store[_index++];
            }
        }
    }
}
