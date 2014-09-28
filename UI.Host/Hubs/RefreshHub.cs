using System;
using Microsoft.AspNet.SignalR;
using NextDashboard.Application;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;
using NLog;
using NLog.Interface;

namespace UI.Host.Hubs
{
    public class RefreshHub : Hub
    {
        private readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());
        private readonly IJobRepository _repository;
        private readonly IJobRefresherFactory _jobRefresherFactory;

        public RefreshHub(IJobRepository repository, IJobRefresherFactory jobRefresherFactory)
        {
            _repository = repository;
            _jobRefresherFactory = jobRefresherFactory;
        }

        public void RefreshJob(string jobId)
        {
            _logger.Info(string.Format("Refreshing Job: {0} for client {1}", jobId, Context.ConnectionId));
            var job = _repository.Select(Int32.Parse(jobId));
            var refresher = _jobRefresherFactory.GetJobRresher(Constants.Jobs.Jenkins);
            var refreshedJob = refresher.RefreshJob(job);
            Clients.Caller.addNewMessageToPage(refreshedJob.Status);
        }
    }
}