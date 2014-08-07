using System.Collections.Generic;
using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application
{
    public interface IJobRepository
    {
        List<Job> SelectAll();
    }
}