using System;
using System.Threading.Tasks;
using OnlineTeaching.DataStore;

namespace OnlineTeaching.Messaging
{
    public abstract class EventDispatcher
    {
        private Topic Topic { get; }
        private EventJournal Journal { get; }
        private bool IsClosed { get; set; }

        protected EventDispatcher(string journalName, string messageBusName, string topicName)
        {
            Journal = EventJournal.Open(journalName);
            Topic = MessageBus.Start(messageBusName).OpenTopic(topicName);
            StartDispatching();
        }

        public virtual void Close()
        {
            IsClosed = true;
        }

        private void StartDispatching()
        {
            Task.Run(() =>
            {
                while (!IsClosed)
                {
                    var journalEvent = Journal.ReadNext();
                    if (journalEvent != null)
                    {
                        var message = new Message(journalEvent.Type, journalEvent.Body, journalEvent.Identifier);
                        Topic.Publish(message);
                    }
                    Task.Delay(TimeSpan.FromMilliseconds(100));
                }
            });
        }
    }
}
