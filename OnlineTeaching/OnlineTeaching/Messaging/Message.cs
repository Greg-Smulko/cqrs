namespace OnlineTeaching.Messaging
{
    public class Message
    {
        public Message(string type, string payload, string id)
        {
            Type = type;
            Payload = payload;
            Id = id;
        }

        public string Id { get; }
        public string Payload { get; }
        public string Type { get; }
    }
}