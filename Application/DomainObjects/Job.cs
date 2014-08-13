namespace NextDashboard.Application.DomainObjects
{
    public abstract class Job : IJob
    {
        protected Job(string name,string status )
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public string Status { get; set; }
     
}

    public interface IJob
    {
     
    }
}