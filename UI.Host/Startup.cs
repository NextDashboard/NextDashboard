using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using NextDashboard.Application.Http;
using NextDashboard.Application.Refreshing;
using NextDashboard.Application.Repository;
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
        
            appBuilder.UseCors(CorsOptions.AllowAll);
            var configuration = new HubConfiguration {EnableDetailedErrors = true, EnableJSONP = true};
            appBuilder.MapSignalR("/signalr",configuration);
            appBuilder.UseNancy();
            AutoMapperWebConfiguration.Configure();
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IJobRepository>().To<JsonJobRepository>();
            kernel.Bind<IJobRefresherFactory>().To<JobRefresherFactory>();
            kernel.Bind<IHttpClientWrapper>().To<HttpClientWrapper>();
            kernel.Bind<IMappingEngine>().ToMethod(context => Mapper.Engine);
            return kernel;
        }
    }
 
}
