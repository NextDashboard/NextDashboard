namespace NextDashboard.Application.DomainObjects
{
    public abstract class Job : IJob
    {
        protected Job()
        {
            
        }
        protected Job(string name,string status )
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public string Status { get; set; }

        public abstract Job Refresh();
    }

    public interface IJob
    {
     
    }
}