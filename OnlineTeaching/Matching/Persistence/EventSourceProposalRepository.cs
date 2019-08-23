using Matching.Domain;
using Matching.Domain.Models;
using OnlineTeaching;
using OnlineTeaching.DataStore;

namespace Matching.Persistence
{
    public class EventSourceProposalRepository : EventSourceRepository, ProposalRepository
    {
        private readonly EventJournal _eventJournal;
        public EventSourceProposalRepository()
        {
            _eventJournal = EventJournal.Open("TalkWithMe-Matching");
        }
        public Proposal ProposalOf(Id id)
        {
            var events = _eventJournal.Read(id.Value);
            var domainEvents = ToDomainEvents(events);
            return new Proposal(domainEvents);
        }

        public void Save(Proposal proposal)
        {
            var events = ToStoreEvents(proposal.Id.Value, proposal.Events);
            _eventJournal.Write(events);
        }
    }
}
