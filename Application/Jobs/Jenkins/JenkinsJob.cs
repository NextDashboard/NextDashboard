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

        public JenkinsJob(string id, string name, string status, string jenkinsBaseUrl, string jenkinsJobName, string username, string apiToken)
            : base(name, status, id)

        {
            JenkinsBaseUrl = jenkinsBaseUrl;
            JenkinsJobName = jenkinsJobName;
            Username = username;
            ApiToken = apiToken;
            Type = Constants.Jobs.Jenkins;
        }


        public JenkinsJob(string id, string name, string status)
            : this(id, name, status, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public override string ToString()
        {
            return
                string.Format(
                    "\tName: {0} \n\r\tStatus :{1} \n\r\tJenkinsJobName: {2} \n\r\tJenkinsBaseUrl: {3} \n\r\tUsername: {4}", 
                    Name,
                    Status, 
                    JenkinsJobName, 
                    JenkinsBaseUrl, 
                    Username);
        }
    }
}