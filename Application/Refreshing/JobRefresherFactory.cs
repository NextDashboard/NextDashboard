using System.Collections.Generic;
using NextDashboard.Application.Http;

namespace NextDashboard.Application.Refreshing
{
    public class JobRefresherFactory : IJobRefresherFactory
    {
        public JobRefresherFactory(IHttpClientWrapper httpClientWrapper)
        {
            _refreshers = new Dictionary<string, IJobRefresher>
            {
                {"Jenkins",new JenkinsJobRefresher(httpClientWrapper)},
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