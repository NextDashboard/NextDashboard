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
                new JenkinsJob("1", "Jenkins Auditing CI", "Passing", JobStatus.Passing, JenkinsBaseUrl, "BB - CI/job/InS Pull Request CI","dblack", "a7df326ea5953842358d999bcb1cc7c8"),
                new JenkinsJob("2", "Jenkins Integration Tests", "Passing", JobStatus.Passing, JenkinsBaseUrl,"Tests/job/Kanga/job/Kanga - Integration Tests", "dblack", "a7df326ea5953842358d999bcb1cc7c8"),
                new SampleJob("3", "Code Reviews", "25 Completed this week, 9 Pending", JobStatus.Failing),
                new SampleJob("4", "TP Sprint 3", "3 of 7 Stories Completed", JobStatus.Passing),
                new SampleJob("5", "Test Job 4", "Passing", JobStatus.Failing)
            };
        }

        public Job Select(int jobId)
        {
            return new JenkinsJob("1", "Test Job 1", "Passing", JobStatus.Passing, JenkinsBaseUrl, "BB - CI/job/InS Pull Request CI", "dblack", "a7df326ea5953842358d999bcb1cc7c8");
        }
    }
}