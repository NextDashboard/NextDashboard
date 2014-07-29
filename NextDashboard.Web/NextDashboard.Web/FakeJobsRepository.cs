using System.Collections.Generic;
using NextDashboard.Web.DataContracts;

namespace NextDashboard.Web
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