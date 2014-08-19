using NextDashboard.Application.DomainObjects;

namespace NextDashboard.Application
{
    public abstract class JobRefresher<T> where T:Job
    {
        public abstract T Refresh(T job);
    }
}