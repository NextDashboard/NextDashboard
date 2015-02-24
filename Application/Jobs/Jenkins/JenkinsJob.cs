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

        public JenkinsJob(string id, string name, string statusDetail, JobStatus status, string jenkinsBaseUrl, string jenkinsJobName, string username, string apiToken)
            : base(name, statusDetail, id, status)

        {
            JenkinsBaseUrl = jenkinsBaseUrl;
            JenkinsJobName = jenkinsJobName;
            Username = username;
            ApiToken = apiToken;
            Type = Constants.Jobs.Jenkins;
        }


        public JenkinsJob(string id, string name, string statusDetail, JobStatus status)
            : this(id, name, statusDetail, status, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public override string ToString()
        {
            return
                string.Format(
                    "\tName: {0} \n\r\tStatusDetail :{1} \n\r\tJenkinsJobName: {2} \n\r\tJenkinsBaseUrl: {3} \n\r\tUsername: {4}", 
                    Name,
                    StatusDetail, 
                    JenkinsJobName, 
                    JenkinsBaseUrl, 
                    Username);
        }
    }
}