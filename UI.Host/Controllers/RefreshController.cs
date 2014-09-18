using System.Web.Http;
using AutoMapper;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;
using NextDashboard.Application.Http;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;

namespace UI.Host.Controllers
{
    public class RefreshController : ApiController
    {
        private readonly IJobRepository _jobRepository;
        private readonly JobRefresherFactory _jobRefresherFactory;
        public RefreshController(IJobRepository jobRepository )
        {
            _jobRepository = jobRepository;
            _jobRefresherFactory = new JobRefresherFactory(new HttpClientWrapper());
            
        }

        public Job Get(int id)
        {
            var job = _jobRepository.Select(id);

            var jobRefresher = _jobRefresherFactory.GetJobRresher(job.Type);
            var jobDto = Mapper.Map<Job>(jobRefresher.RefreshJob(job));
            return jobDto;
        }
    }
}