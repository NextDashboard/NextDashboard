using System.Collections.Generic;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Repository
{
    public class FakeJobRepository : IJobRepository
    {
        public List<Job> SelectAll()
        {
            return new List<Job>
            {
                new JenkinsJob("Test Job 1", "Passing"),
                new JenkinsJob("Test Job 2", "25 Completed this week, 9 Pending"),
                new JenkinsJob("Test Job 3", "Failing"),
                new JenkinsJob("QA TestAutomation", "Failing"),
                new JenkinsJob("TP Sprint 3", "3 of 7 Stories Completed"),
                new JenkinsJob("Code Reviews", "25 Completed this week, 9 Pending")
            };
        }
    }
}