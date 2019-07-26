using System;

namespace OnlineTeaching.DataStore
{
    public class EventEntity
    {
        public string Identifier { get; }
        public string Type { get; }
        public string Body { get; }

        public EventEntity(string identifier, string payload, string type)
        {
            Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
            Body = payload ?? throw new ArgumentNullException(nameof(payload));
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }
    }
}