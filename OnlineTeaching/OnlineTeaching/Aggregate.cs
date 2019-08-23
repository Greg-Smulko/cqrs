using System.Collections.Generic;

namespace OnlineTeaching
{
    public abstract class Aggregate
    {
        public List<DomainEvent> Events { get; }

        protected Aggregate()
        {
            Events = new List<DomainEvent>();
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
            Events.Add(domainEvent);
            DispatchWhen(domainEvent);
        }

        private void DispatchWhen(DomainEvent domainEvent)
        {
            ((dynamic)this).When((dynamic)domainEvent);
        }
    }
}