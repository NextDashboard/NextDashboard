using System.Collections.Generic;

namespace NextDashboard.Api
{
    public interface IJobsRepository
    {
        List<Job> SelectAll();
    }
}