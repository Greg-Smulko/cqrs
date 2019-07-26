using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlineTeaching.DataStore
{
    public abstract class EventSourceRepository
    {
        public IEnumerable<DomainEvent> ToDomainEvents(IEnumerable<EventEntity> events)
        {
            var domainEvents = new List<DomainEvent>();
            foreach (var ev in events)
            {
                domainEvents.Add(JsonConvert.DeserializeObject<DomainEvent>(ev.Body));
            }

            return domainEvents;
        }

        public IEnumerable<EventEntity> ToEventSourceEvents(string identifier, IEnumerable<DomainEvent> events)
        {
            var esEvents = new List<EventEntity>();
            foreach (var ev in events)
            {
                var body = JsonConvert.SerializeObject(ev);
                esEvents.Add(new EventEntity(identifier, body, ev.GetType().AssemblyQualifiedName));
            }

            return esEvents;
        }
    }
}
