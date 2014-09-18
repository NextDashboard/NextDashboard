using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application.Refreshing
{
    public interface IJobRefresher
    {
        Job RefreshJob(Job job);
    }
}