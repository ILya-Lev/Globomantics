using Globomantics.Core.Models;
using Globomantics.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    [TypeFilter(typeof(FeatureAuthFilter), Arguments = new object[] { FeatureAuthFilter.InsuranceFeatureName })]
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
