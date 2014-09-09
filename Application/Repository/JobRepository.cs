using System.Collections.Generic;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.Repository
{
    public class JobRepository : IJobRepository
    {
        public List<Job> SelectAll()
        {
            return new List<Job>
            {
                new JenkinsJob("Test Job 1", "Passing"),
                new JenkinsJob("Code Reviews", "25 Completed this week, 9 Pending")
            };
        }

        public Job Select(int jobId)
        {
          return  new JenkinsJob("testRefresh", "Passing");
        }
    }
}