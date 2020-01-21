using NonFactors.Mvc.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CurrencyView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public string CurrencyCode { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public virtual List<CurrencyRate> CurrencyRateFromCurrencyCodeNavigation { get; set; }
        public virtual List<CurrencyRate> CurrencyRateToCurrencyCodeNavigation { get; set; }
    }
}
