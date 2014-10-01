namespace NextDashboard.Application.DomainObjects
{
    public abstract class Job
    {
        protected Job()
        {
        }

        protected Job(string name, string status, string id)
        {
            Name = name;
            Status = status;
        }

        public string Name { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}