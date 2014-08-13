using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application
{
    public class JobRefresher
    {
        public Job Refresh(Job job)
        {
            job.Status = "Refreshed";
            return job;
        }
    }
}