using System.Collections.Generic;
using System.Net;
using NextDashboard.Web.DataContracts;

namespace NextDashboard.Web
{
    public class JobRepository : IJobsRepository
    {
        public List<Job> SelectAll()
        {
            string json = new WebClient().DownloadString("api/job");


            var jobsRepository = new FakeJobsRepository();
            return jobsRepository.SelectAll();
        }
    }
}