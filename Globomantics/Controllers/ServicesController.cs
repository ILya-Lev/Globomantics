using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
