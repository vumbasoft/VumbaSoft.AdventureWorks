using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CountryRegionCurrency : BaseModel
    {
        public Int32 CountryRegionId { get; set; }
        public Int32 CurrencyId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual CountryRegion CountryRegionCodeNavigation { get; set; }
        public virtual Currency CurrencyCodeNavigation { get; set; }
    }
}
