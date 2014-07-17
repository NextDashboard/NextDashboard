using System.Collections.Generic;
using System.Web.Http;

namespace NextDashboard.Api.Contollers
{
    public class JobsController : ApiController
    {
        private readonly IJobsRepository _jobsRepository;

        public JobsController(IJobsRepository jobsRepository)
        {
            _jobsRepository = jobsRepository;
        }

        // GET api/values 
        public List<Job> Get()
        {
         return   _jobsRepository.SelectAll();
        }
    }
}