namespace NextDashboard.Application.Refreshing
{
    public interface IJobRefresherFactory
    {
        IJobRefresher GetJobRresher(string jobType);
    }
}