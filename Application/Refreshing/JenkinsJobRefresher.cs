using System;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Http;
using NextDashboard.Application.Jobs.Jenkins;
using NLog;
using NLog.Interface;

namespace NextDashboard.Application.Refreshing
{
    public class JenkinsJobRefresher : IJobRefresher
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly ILogger _logger = new LoggerAdapter(LogManager.GetCurrentClassLogger());

        public JenkinsJobRefresher(IHttpClientWrapper httpClientWrapper)
        {
            _logger.Trace("Initialized");
            _httpClientWrapper = httpClientWrapper;
        }

        public Job RefreshJob(Job job)
        {
            var jenkinsJob = (JenkinsJob) job;
            _logger.Trace("Refreshing Jenkins Job \n\r{0}", jenkinsJob.ToString());
            
            _httpClientWrapper.BaseAddress = new Uri(jenkinsJob.JenkinsBaseUrl);
            var address = string.Format("job/{0}/lastBuild/api/json", jenkinsJob.JenkinsJobName);
            _httpClientWrapper.SetHeaderUserNameAndPassword(jenkinsJob.Username, jenkinsJob.ApiToken);
            var jobResponse = _httpClientWrapper.GetResponse(address);
            var buildResponse = JsonConvert.DeserializeObject<JenkinsBuildResponse>(jobResponse);
            
            job.Status = buildResponse.result;
            _logger.Trace("Jenkins job Refresh complete with status {0}", job.Status);
            return job;
        }
    }
}