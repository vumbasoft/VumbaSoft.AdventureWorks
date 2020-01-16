using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CountryRegion : BaseModel
    {
        public string Title { get; set; }
        public string CountryRegionCode { get; set; }
        public String Remarks { get; set; }
        public virtual List<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public virtual List<StateProvince> StateProvince { get; set; }

    }
}
