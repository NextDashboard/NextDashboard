using System;
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
        private readonly IMappingEngine _mappingEngine;

        public JobController(IJobRepository jobRepository, IMappingEngine mappingEngine)
        {
            _jobRepository = jobRepository;
            _mappingEngine = mappingEngine;
        }

        // GET api/values 
        public List<Job> Get()
        {
            var jobs = _mappingEngine.Map<List<Job>>(_jobRepository.SelectAll());
            return jobs;
        }

    }
}