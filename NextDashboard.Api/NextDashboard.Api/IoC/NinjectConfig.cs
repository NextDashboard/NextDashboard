using Ninject;

namespace NextDashboard.Api.IoC
{
    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IJobsRepository>().To<FakeJobsRepository>();
            return kernel;
        }
    }
}