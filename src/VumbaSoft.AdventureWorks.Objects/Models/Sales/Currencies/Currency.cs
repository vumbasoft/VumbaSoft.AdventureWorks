using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Currency : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }
        public String CurrencyCode { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public virtual List<CurrencyRate> CurrencyRateFromCurrencyCodeNavigation { get; set; }
        public virtual List<CurrencyRate> CurrencyRateToCurrencyCodeNavigation { get; set; }
    }
}
