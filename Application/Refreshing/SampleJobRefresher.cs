using System;
using NLog;
using NLog.Interface;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Refreshing
{
    public class SampleJobRefresher : IJobRefresher
    {
        private readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

        #region IJobRefresher Members

        public Job RefreshJob(Job job)
        {
            _logger.Trace("Refreshing sample job");
            var random = new Random();
            job.StatusDetail = random.NextDouble() > 0.5 ? "Passing" : "Failing";
            if (random.NextDouble() > 0.5)
            {
                job.StatusDetail = "Passing!";
                job.Status = JobStatus.Passing;
            }
            else
            {
                job.StatusDetail = "Failing!";
                job.Status = JobStatus.Failing;
            }

            _logger.Trace("Sample job randomly generated status: {0}", job.StatusDetail);
            return job;
        }

        #endregion
    }
}