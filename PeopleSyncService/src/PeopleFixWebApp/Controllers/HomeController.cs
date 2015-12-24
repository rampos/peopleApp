
using Microsoft.AspNet.Mvc;


namespace PeopleFixWebApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private static string[] scopes = { "https://outlook.office.com/mail.read" };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

        

      
    }
}
