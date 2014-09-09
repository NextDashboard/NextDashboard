using NextDashboard.Application.Http;
using NextDashboard.Application.Jobs.Jenkins;

namespace NextDashboard.Application.DomainObjects
{
    public class JenkinsJob : Job
    {
        public readonly string JenkinsBaseUrl;
        public readonly string JenkinsJobName;
        private readonly JobRefresher<JenkinsJob> _jobRefresher;

        public JenkinsJob()
        {
            
        }
        public JenkinsJob(string name, string status, string jenkinsBaseUrl, string jenkinsJobName, JobRefresher<JenkinsJob> jobRefresher)
            : base(name, status)
        
        {
            JenkinsBaseUrl = jenkinsBaseUrl;
            JenkinsJobName = jenkinsJobName;
            _jobRefresher = jobRefresher;
        }

        public JenkinsJob(string name, string status, string jenkinsBaseUrl, string jenkinsJobName)
            : this(name, status,jenkinsBaseUrl, jenkinsJobName, new JenkinsJobRefresher(new HttpClientWrapper()))
        {
        }

        public JenkinsJob(string name, string status)
            :this(name,status,string.Empty,string.Empty, new JenkinsJobRefresher(new HttpClientWrapper()))
        {
        }


        public override Job Refresh()
        {
            return _jobRefresher.Refresh(this);
        }
    }
}