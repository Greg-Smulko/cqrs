using Matching.Domain;
using Matching.Persistence;

namespace Matching.Application
{
    public static class Api
    {
        public static ProposalCommands ProposalCommands => new ProposalCommands(Repositories.ProposalRepository);
    }
}
