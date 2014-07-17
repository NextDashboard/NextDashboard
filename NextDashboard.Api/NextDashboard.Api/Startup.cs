﻿using System.Web.Http;
using NextDashboard.Api.IoC;
using Owin;

namespace NextDashboard.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.DependencyResolver = new NinjectResolver(NinjectConfig.CreateKernel());

            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new {id = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }
}