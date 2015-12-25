
using Microsoft.AspNet.Mvc;
using PeopleFixWebApp.Connectors;
using System.Threading.Tasks;

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

        public async Task<string> Test()
        {
            MicrosoftConnector msConnector = new MicrosoftConnector();
            return await msConnector.GetContactsAsync();
        }

      
    }
}
