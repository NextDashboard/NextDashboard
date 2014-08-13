using System.Web.Http;
using AutoMapper;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;

namespace UI.Host.Controllers
{
    public class RefreshController : ApiController
    {

        public Job Get(int id)
        {
            var jobRepository = new JobRepository();
            NextDashboard.Application.DomainObjects.Job job = jobRepository.Select(id);

            var refresher = new JobRefresher();
            NextDashboard.Application.DomainObjects.Job refreshedJob = refresher.Refresh(job);

            var jobDto = Mapper.Map<Job>(refreshedJob);
            return jobDto;
        }
    }
}