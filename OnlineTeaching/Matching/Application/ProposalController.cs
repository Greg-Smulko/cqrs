using System;
using System.Collections.Generic;
using Matching.Domain;

namespace Matching.Application
{
    public class ProposalController
    {
        public void SubmitProposal(string studentId, string summary, string description, string language,
            DateTime startDate, DateTime? endDate, List<DayOfWeek> schedule)
        {
            API.ProposalCommands.Submit(studentId, summary, description, language, startDate, endDate,
                schedule);
        }
    }
}
