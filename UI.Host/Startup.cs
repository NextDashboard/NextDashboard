using System.Web.Http;
using AutoMapper;
using NextDashboard.Application;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

namespace UI.Host
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseNinjectMiddleware(CreateKernel);
            appBuilder.UseNinjectWebApi(config);

            appBuilder.UseNancy();
            AutoMapperWebConfiguration.Configure();
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IJobRepository>().To<FakeJobRepository>();
            kernel.Bind<IMappingEngine>().ToMethod(context => Mapper.Engine);
            return kernel;
        }
    }
}
