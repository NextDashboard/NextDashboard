using System.Collections.Generic;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.Repository
{
    public class FakeJobRepository : IJobRepository
    {
        private const string JenkinsBaseUrl = "http://jenkins.msohosting.local:8080";

        public List<Job> SelectAll()
        {
            return new List<Job>
            {
                new JenkinsJob("Test Job 1", "Passing", JenkinsBaseUrl, "BB - CI/job/Auditing CI"),
                new JenkinsJob("Test Job 2", "25 Completed this week, 9 Pending", JenkinsBaseUrl, "BB - CI/job/Auditing CI"),
                new JenkinsJob("Test Job 3", "Failing", JenkinsBaseUrl, "BB - CI/job/Auditing CI"),
                new JenkinsJob("QA TestAutomation", "Failing", JenkinsBaseUrl, "BB - CI/job/Auditing CI"),
                new JenkinsJob("TP Sprint 3", "3 of 7 Stories Completed", JenkinsBaseUrl, "BB - CI/job/Auditing CI"),
                new JenkinsJob("Code Reviews", "25 Completed this week, 9 Pending", JenkinsBaseUrl, "BB - CI/job/Auditing CI")
            };
        }

        public Job Select(int jobId)
        {
            return new JenkinsJob("Test Job 1", "Passing");
        }
    }
}