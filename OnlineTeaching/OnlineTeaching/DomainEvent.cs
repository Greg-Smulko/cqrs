using System;

namespace OnlineTeaching
{
    public abstract class DomainEvent
    {
        public int EventVersion { get; }
        public DateTime OccurredOn { get; }
        protected DomainEvent():this(1) { }

        protected DomainEvent(int eventVersion)
        {
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
        }
    }
}