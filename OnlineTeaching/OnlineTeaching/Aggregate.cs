using System.Collections.Generic;

namespace OnlineTeaching
{
    public abstract class Aggregate
    {
        public List<DomainEvent> MutatingEvents { get; }

        protected Aggregate()
        {
            MutatingEvents = new List<DomainEvent>();
        }

        protected Aggregate(IEnumerable<DomainEvent> events) : this()
        {
            foreach (var domainEvent in events)
            {
                DispatchWhen(domainEvent);
            }
        }

        protected void Apply(DomainEvent domainEvent)
        {
            MutatingEvents.Add(domainEvent);
            DispatchWhen(domainEvent);
        }

        protected void DispatchWhen(DomainEvent domainEvent)
        {
            ((dynamic)this).When((dynamic)domainEvent);
        }
    }
}