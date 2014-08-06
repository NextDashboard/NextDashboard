using Nancy;

namespace UI.Host.Owin
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                var model = new { title = "NextDashboard" };
                return View["home", model];
            };
        }
    }
}