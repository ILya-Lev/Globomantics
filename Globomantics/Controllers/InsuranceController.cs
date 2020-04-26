using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class InsuranceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
