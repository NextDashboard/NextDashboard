namespace NextDashboard.Application.DomainObjects
{
    public class SampleJob : Job
    {
        public SampleJob(string id, string name, string status) : base(name, status, id)
        {
            Type = Constants.Jobs.Sample;
        }
    }
}