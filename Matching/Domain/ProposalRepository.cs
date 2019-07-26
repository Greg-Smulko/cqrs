using Matching.Domain.Models;
using OnlineTeaching;

namespace Matching.Domain
{
    public interface ProposalRepository
    {
        Proposal ProposalOf(Id id);
        void Save(Proposal proposal);
    }
}
