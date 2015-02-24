namespace NextDashboard.Application.DomainObjects
{
    public class SampleJob : Job
    {
        public SampleJob(string id, string name, string statusDetail, JobStatus status)
            : base(name, statusDetail, id, status)
        {
            Type = Constants.Jobs.Sample;
        }
    }
}