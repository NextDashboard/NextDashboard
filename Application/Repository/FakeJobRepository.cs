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
                new JenkinsJob("1","Test Job 1", "Passing", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712"),
                new JenkinsJob("2","Test Job 2", "25 Completed this week, 9 Pending", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712"),
                new JenkinsJob("3","Test Job 3", "Failing", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712"),
                new JenkinsJob("4","QA TestAutomation", "Failing", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712"),
                new JenkinsJob("5","TP Sprint 3", "3 of 7 Stories Completed", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712"),
                new JenkinsJob("6","Code Reviews", "25 Completed this week, 9 Pending", JenkinsBaseUrl, "BB - CI/job/Auditing CI","dblack","5dd12d253bb6ff1376f3b5a5a9333712")
            };
        }

        public Job Select(int jobId)
        {
            return new JenkinsJob("1","Test Job 1", "Passing", JenkinsBaseUrl, "BB - CI/job/Auditing CI", "dblack", "5dd12d253bb6ff1376f3b5a5a9333712");
        }
    }
}