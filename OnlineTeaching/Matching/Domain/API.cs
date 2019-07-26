using Matching.Persistence;

namespace Matching.Domain
{
    public static class API
    {
        public static ProposalCommands ProposalCommands => new ProposalCommands(Repositories.ProposalRepository);
    }
}
