using System.Web.Http;
using AutoMapper;
using NextDashboard.Application;
using NextDashboard.Application.DataContracts;
using NextDashboard.Application.Repository;

namespace UI.Host.Controllers
{
    public class RefreshController : ApiController
    {

        public Job Get(int id)
        {
            var jobRepository = new JobRepository();
            NextDashboard.Application.DomainObjects.Job job = jobRepository.Select(id);

            Job jobDto = Mapper.Map<Job>(job.Refresh());
            return jobDto;
        }
    }
}