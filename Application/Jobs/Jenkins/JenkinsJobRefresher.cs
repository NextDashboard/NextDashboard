using System;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;
using NextDashboard.Application.Http;

namespace NextDashboard.Application.Jobs.Jenkins
{
    public class JenkinsJobRefresher : JobRefresher<JenkinsJob>
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private string _baseUrl;
        private string _jobName;

        public JenkinsJobRefresher(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public override JenkinsJob Refresh(JenkinsJob job)
        {
            _jobName = job.JenkinsJobName;
            _baseUrl = job.JenkinsBaseUrl;
            _httpClientWrapper.BaseAddress = new Uri(_baseUrl);
            var jobResponse = _httpClientWrapper.GetResponse(string.Format("job/{0}/lastBuild/api/json", _jobName));
            var buildResponse = JsonConvert.DeserializeObject<JenkinsBuildResponse>(jobResponse);
            job.Status = buildResponse.result;
            return job;
        }
    }
}