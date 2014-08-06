using System.Collections.Generic;
using System.Web.Http;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;

namespace UI.Host.Controllers
{
    public class JobController : ApiController
    {
        private readonly IJobsRepository _jobsRepository;

        public JobController()
        {
            _jobsRepository = new FakeJobsRepository();
        }

        // GET api/values 
        public List<Job> Get()
        {
            return _jobsRepository.SelectAll();
        }
    }
}