using System.Web.Mvc;

namespace NextDashboard.Web.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            return View();
        }
    }
}