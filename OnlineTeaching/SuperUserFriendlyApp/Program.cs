using System;
using System.Linq;
using Matching.Domain;
using Matching.Persistence;

namespace SuperUserFriendlyApp
{
    class Program
    {
        static ProposalCommands proposalCommandHandler = new ProposalCommands(new EventSourceProposalRepository());
        static void Main(string[] args)
        {
            Matching.Application.StartUp.Main();
            Profile.Application.StartUp.Main();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                var studentId = Guid.NewGuid().ToString();
                const string makeProposal = "make-proposal";
                const string showProposalStatus = "show-proposal-status";
                const string tutorAcceptsProposal = "accept-proposal";
                const string tutorRejectsProposal = "reject-proposal";
                if (line.StartsWith(makeProposal))
                {
                    var proposalContent = line.Substring(makeProposal.Length + 1).Split(' ');
                    var language = proposalContent[0];
                    var daysOfTheWeek = proposalContent[1].Split(',').Select(d => (DayOfWeek)int.Parse(d)).ToList();
                    proposalCommandHandler.Submit(studentId, "", "", language, DateTime.UtcNow, DateTime.UtcNow.AddHours(1), daysOfTheWeek);
                }
                else if (line.StartsWith(showProposalStatus))
                {
                    var proposalId = line.Substring(showProposalStatus.Length + 1);

                }
                else if (line.StartsWith(tutorAcceptsProposal))
                {

                }
                else if (line.StartsWith(tutorRejectsProposal))
                {

                }
            }
        }

        static void Start()
        {

        }
    }
}
