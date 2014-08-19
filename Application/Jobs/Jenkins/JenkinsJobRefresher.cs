using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NextDashboard.Application.DomainObjects;

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
            //  var client = new HttpClient();
            _jobName = job.JenkinsJobName;
            _baseUrl = job.JenkinsBaseUrl;

            _httpClientWrapper.BaseAddress = new Uri(_baseUrl);


            var jobResponse = _httpClientWrapper.GetResponse(string.Format("job/{0}/lastBuild/api/json", _jobName));
            //var response = _httpClientWrapper.GetAsync(string.Format("job/{0}/lastBuild/api/json", _jobName)).Result;
            //Task<string> jobResponse = response.Content.ReadAsStringAsync();

            var buildResponse = JsonConvert.DeserializeObject<JenkinsBuildResponse>(jobResponse);
            job.Status = buildResponse.result;
            return job;
        }
    }

    public interface IHttpClientWrapper
    {
        Uri BaseAddress { get; set; }
        string GetResponse(string address);
    }

    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public HttpClientWrapper()
        {
            client = new HttpClient();
        }

        public Uri BaseAddress
        {
            get { return client.BaseAddress; }
            set { client.BaseAddress = value; }
        }

        public string GetResponse(string address)
        {
            var response = client.GetAsync(address).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

    }
}