using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class CreditCardRatesViewComponent : ViewComponent
    {
        private IRateService _rateService;

        public CreditCardRatesViewComponent(IRateService rateService)
        {
            _rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            string title, string subtitle)
        {
            var ratesVM = new CreditCardWidgetVM()
            {
                Rates = _rateService.GetCreditCardRates(),
                WidgetTitle = title,
                WidgetSubTitle = subtitle
            };

            return View(ratesVM);
        }
    }
}
