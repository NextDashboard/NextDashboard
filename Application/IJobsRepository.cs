using System.Collections.Generic;
using NextDashboard.Application.DataContracts;

namespace NextDashboard.Application
{
    public interface IJobsRepository
    {
        List<Job> SelectAll();
    }
}