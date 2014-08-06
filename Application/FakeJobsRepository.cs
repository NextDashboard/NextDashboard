using System.Collections.Generic;
using NextDashboard.Application.DataContracts;

namespace NextDashboard.Application
{
    public class FakeJobsRepository : IJobsRepository
    {
        public List<Job> SelectAll()
        {
            return new List<Job>
            {
                new Job("Test Job 1", "Passing"),
                new Job("Test Job 2", "25 Completed this week, 9 Pending"),
                new Job("Test Job 3", "Failing"),
                new Job("QA TestAutomation", "Failing"),
                new Job("TP Sprint 3", "3 of 7 Stories Completed"),
                new Job("Code Reviews", "25 Completed this week, 9 Pending")
            };
        }
    }
}