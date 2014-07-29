using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NextDashboard.UI.Web.Startup))]

namespace NextDashboard.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();

            app.Run(context =>
            {
                if (context.Request.Path.Value == "/fail")
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}
