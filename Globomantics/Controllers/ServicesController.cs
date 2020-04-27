using Globomantics.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    [TypeFilter(typeof(FeatureAuthFilter), Arguments = new object[] { FeatureAuthFilter.BusinessFeatureName })]
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
