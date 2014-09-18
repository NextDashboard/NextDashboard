using System.Collections.Generic;
using NextDashboard.Application.Http;

namespace NextDashboard.Application.Refreshing
{
    public class JobRefresherFactory
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public JobRefresherFactory(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
            _refreshers = new Dictionary<string, IJobRefresher>()
            {
                {"Jenkins",new JenkinsJobRefresher(_httpClientWrapper)},
                {"Sample",new SampleJobRefresher()}
            };
        }
        private readonly Dictionary<string, IJobRefresher> _refreshers;

        public IJobRefresher GetJobRresher(string jobType)
        {
            return _refreshers[jobType];
        }
    }
}