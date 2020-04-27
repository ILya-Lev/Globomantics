using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : IAuthorizationFilter
    {
        private readonly IFeatureService _featureService;
        private readonly string _featureName;

        public const string LoanFeatureName = "Loans";
        public const string InsuranceFeatureName = "Quotes";
        public const string ResourcesFeatureName = "Resources";
        public const string BusinessFeatureName = "BusinessServices";

        public FeatureAuthFilter(IFeatureService featureService, string featureName)
        {
            _featureService = featureService;
            _featureName = featureName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_featureService.IsFeatureActive(_featureName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}