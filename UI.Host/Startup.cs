using System.Web.Http;
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
using UI.Host.IoC;

namespace UI.Host
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional}
                );
            appBuilder.UseNinjectMiddleware(CreateKernel);
            appBuilder.UseNinjectWebApi(config);
            appBuilder.UseCors(CorsOptions.AllowAll);
            var configuration = new HubConfiguration
            {
                EnableDetailedErrors = true,
                EnableJSONP = true,
                Resolver = new SignalRNinjectDependencyResolver(CreateKernel())
            };
            appBuilder.MapSignalR("/signalr", configuration);
            appBuilder.UseNancy();
            AutoMapperWebConfiguration.Configure();
        }

        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new StandardModule());
            return kernel;
        }
    }
}