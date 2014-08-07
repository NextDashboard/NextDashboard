using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;

namespace UI.Host.Controllers
{
    public class JobController : ApiController
    {
        private readonly IJobRepository _jobRepository;

        public JobController()
        {
            _jobRepository = new FakeJobRepository();
        }

        // GET api/values 
        public List<Job> Get()
        {
            Mapper.CreateMap<NextDashboard.Application.DomainObjects.Job, Job>();
            var jobs = Mapper.Map<List<Job>>(_jobRepository.SelectAll());
            return jobs;
        }
    }
}