using System.Collections.Generic;

namespace NextDashboard.Web.DataContracts
{
    public interface IJobsRepository
    {
        List<Job> SelectAll();
    }
}