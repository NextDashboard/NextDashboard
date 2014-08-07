namespace NextDashboard.Application.DomainObjects
{
    public class JenkinsJob : Job
    {
        public JenkinsJob(string name, string status) : base(name, status)
        {
        }

        public override void Refresh()
        {
            Status = "Refreshed!";
        }
    }
}