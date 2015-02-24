using System.Web.Http;
using AutoMapper;
using NLog;
using NLog.Interface;
using NextDashboard.Application.DataContracts;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;

namespace UI.Host.Controllers
{
    public class RefreshController : ApiController
    {
        private readonly IJobRefresherFactory _jobRefresherFactory;
        private readonly IJobRepository _jobRepository;
        private static readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        public RefreshController(IJobRepository jobRepository, IJobRefresherFactory jobRefresherFactory)
        {
            _logger.Info("Instantiating Refresh Controller");
            _jobRepository = jobRepository;
            _jobRefresherFactory = jobRefresherFactory;
        }

        public Job Get(int id)
        {
            _logger.Info("Refreshing {0}"+id);
            NextDashboard.Application.DomainObjects.Job job = _jobRepository.Select(id);

            var jobRefresher = _jobRefresherFactory.GetJobRresher(job.Type);
            var jobDto = Mapper.Map<Job>(jobRefresher.RefreshJob(job));
            return jobDto;
        }
    }
}