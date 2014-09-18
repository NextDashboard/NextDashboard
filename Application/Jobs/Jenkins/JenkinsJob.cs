using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Jobs.Jenkins
{
    public class JenkinsJob : Job
    {
        public string JenkinsBaseUrl;
        public string JenkinsJobName;

        public JenkinsJob()
        {
        }

        public JenkinsJob(string name, string status, string jenkinsBaseUrl, string jenkinsJobName)
            : base(name, status)

        {
            JenkinsBaseUrl = jenkinsBaseUrl;
            JenkinsJobName = jenkinsJobName;
            Type = Constants.Jobs.Jenkins;
        }


        public JenkinsJob(string name, string status)
            : this(name, status, string.Empty, string.Empty)
        {
        }
    }
}