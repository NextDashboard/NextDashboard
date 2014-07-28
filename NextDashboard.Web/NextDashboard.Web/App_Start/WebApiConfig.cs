using System.Web.Http;

namespace NextDashboard.Web
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", 
                    new {id = RouteParameter.Optional}
                );
        }
    }
}