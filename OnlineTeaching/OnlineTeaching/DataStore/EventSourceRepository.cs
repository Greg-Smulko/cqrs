using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OnlineTeaching.DataStore
{
    public abstract class EventSourceRepository
    {
        protected IEnumerable<DomainEvent> ToDomainEvents(IEnumerable<EventEntity> events)
        {
            var domainEvents = new List<DomainEvent>();
            foreach (var ev in events)
            {
                var type = Type.GetType(ev.Type);
                domainEvents.Add((DomainEvent)JsonConvert.DeserializeObject(ev.Body, type, new JsonSerializerSettings()));
            }

            return domainEvents;
        }

        protected IEnumerable<EventEntity> ToStoreEvents(string identifier, IEnumerable<DomainEvent> events)
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
