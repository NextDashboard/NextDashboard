using AutoMapper;
using NextDashboard.Application.Http;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;
using Ninject.Modules;

namespace UI.Host.IoC
{
    public class StandardModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IJobRepository>().To<JsonJobRepository>();
            Bind<IJobRefresherFactory>().To<JobRefresherFactory>();
            Bind<IHttpClientWrapper>().To<HttpClientWrapper>();
            Bind<IMappingEngine>().ToMethod(context => Mapper.Engine);
        }
    }
}