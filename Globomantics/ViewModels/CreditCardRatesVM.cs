using System.Collections.Generic;
using Globomantics.Core.Models;

namespace Globomantics.ViewModels
{
    public class CreditCardRatesVM
    {
        public IReadOnlyCollection<Rate> Rates { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}