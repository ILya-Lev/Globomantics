using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Globomantics.ViewModels;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private readonly IRateService _rateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            _rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string title, string subTitle)
        {
            var model = new CreditCardRatesVM()
            {
                Rates = _rateService.GetCreditCardRates(),
                Title = title,
                SubTitle = subTitle
            };
            return View(model);
        }
    }
}
