using System.Collections.Generic;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Repository
{
    public interface IJobRepository
    {
        List<Job> SelectAll();
    }
}