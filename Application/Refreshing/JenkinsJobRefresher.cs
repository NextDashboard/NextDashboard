using System;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Http;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.Refreshing
{
    public class JenkinsJobRefresher : IJobRefresher
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public JenkinsJobRefresher(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public Job RefreshJob(Job job)
        {
            var jenkinsJob = (JenkinsJob) job;
            _httpClientWrapper.BaseAddress = new Uri(jenkinsJob.JenkinsBaseUrl);
            var address = string.Format("job/{0}/lastBuild/api/json", jenkinsJob.JenkinsJobName);
            _httpClientWrapper.SetHeaderUserNameAndPassword(jenkinsJob.Username, jenkinsJob.ApiToken);
            var jobResponse = _httpClientWrapper.GetResponse(address);

            var buildResponse = JsonConvert.DeserializeObject<JenkinsBuildResponse>(jobResponse);
            job.Status = buildResponse.result;
            return job;
        }
    }
}