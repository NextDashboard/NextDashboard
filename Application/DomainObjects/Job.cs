namespace NextDashboard.Application.DomainObjects
{
    public abstract class Job
    {
        protected Job()
        {
        }

        protected Job(string name, string statusDetail, string id,JobStatus status)
        {
            Name = name;
            StatusDetail = statusDetail;
            Id = id;
            Status = status;
        }

        public string Name { get; set; }
        public string StatusDetail { get; set; }
        public string Type { get; set; }
        public string Id { get; set; }
        public JobStatus Status { get; set; }
    
}
}