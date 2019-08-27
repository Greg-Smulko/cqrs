using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace OnlineTeaching.Messaging
{
    public class Topic
    {
        public string Name { get; }
        private ConcurrentQueue<Message> Queue { get; }
        private ConcurrentBag<ISubscriber> Subscribers { get; }
        private bool IsClosed { get; set; }

        public void Close()
        {
            IsClosed = true;
            Queue.Clear();
        }

        public void Publish(Message message)
        {
            Queue.Enqueue(message);
        }

        public void Subscribe(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        internal Topic(string name)
        {
            Name = name;
            Queue = new ConcurrentQueue<Message>();
            Subscribers = new ConcurrentBag<ISubscriber>();
            StartDispatch();
        }

        private void StartDispatch()
        {
            Task.Run(() =>
            {
                while (!IsClosed)
                {
                    if (Queue.TryDequeue(out var message))
                    {
                        foreach (var subscriber in Subscribers)
                        {
                            try
                            {
                                subscriber.Handle(message);
                            }
                            catch (Exception ex)
                            {
                                var error = ex.Message;
                            }
                        }
                    }
                    Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            });
        }
    }
}