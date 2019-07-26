using Matching.Domain;

namespace Matching.Persistence
{
    public class Repositories
    {
        public static ProposalRepository ProposalRepository => new EventSourceProposalRepository();
    }
}
