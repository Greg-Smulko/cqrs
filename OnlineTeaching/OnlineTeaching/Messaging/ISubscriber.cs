namespace OnlineTeaching.Messaging
{
    public interface ISubscriber
    {
        void Handle(Message message);
    }
}