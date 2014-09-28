using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Jobs.Jenkins
{
    public class JenkinsJob : Job
    {
        public string JenkinsBaseUrl;
        public string JenkinsJobName;
        public string Username;
        public string ApiToken;

        public JenkinsJob()
        {
        }

        public JenkinsJob(string name, string status, string jenkinsBaseUrl, string jenkinsJobName, string username, string apiToken)
            : base(name, status)

        {
            JenkinsBaseUrl = jenkinsBaseUrl;
            JenkinsJobName = jenkinsJobName;
            Username = username;
            ApiToken = apiToken;
            Type = Constants.Jobs.Jenkins;
        }


        public JenkinsJob(string name, string status)
            : this(name, status, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }
    }
}