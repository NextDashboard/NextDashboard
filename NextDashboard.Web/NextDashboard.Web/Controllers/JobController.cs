using System.Collections.Generic;
using System.Web.Http;
using NextDashboard.Web.DataContracts;

namespace NextDashboard.Web.Controllers
{
    public class JobController : ApiController
    {
        private readonly IJobsRepository _jobsRepository;

        public JobController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        // GET api/values 
        public List<Job> Get()
        {
            return _jobsRepository.SelectAll();
        }
    }
}