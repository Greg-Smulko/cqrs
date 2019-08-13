using System;

namespace OnlineTeaching
{
    public class Id
    {
        public string Value { get; }

        public static Id Unique()
        {
            return new Id();
        }

        public static Id FromExisting(string id)
        {
            return new Id(id);
        }

        private Id()
        {
            Value = Guid.NewGuid().ToString();
        }

        private Id(string id)
        {
            Value = id;
        }
    }
}