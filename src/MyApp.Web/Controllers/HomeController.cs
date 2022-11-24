using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    public class HomeController : MyAppControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}