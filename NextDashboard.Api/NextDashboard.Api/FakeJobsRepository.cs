using System.Collections.Generic;

namespace NextDashboard.Api
{
    public class FakeJobsRepository : IJobsRepository
    {
        public List<Job> SelectAll()
        {
            return new List<Job>
            {
                new Job("Test Job 1"),
                new Job("Test Job 2"),
                new Job("Test Job 3")
            };
        }
    }
}