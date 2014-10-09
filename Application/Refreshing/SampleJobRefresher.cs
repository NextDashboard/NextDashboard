using System;
using NLog;
using NLog.Interface;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Refreshing
{
    public class SampleJobRefresher : IJobRefresher
    {
        private readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        public Job RefreshJob(Job job)
        {
            _logger.Trace("Refreshing sample job");
            var random = new Random();
            job.Status = random.NextDouble() > 0.5 ? "Passing" : "Failing";
            _logger.Trace("Sample job randomly generated status: {0}",job.Status);
            return job;
        }
    }
}