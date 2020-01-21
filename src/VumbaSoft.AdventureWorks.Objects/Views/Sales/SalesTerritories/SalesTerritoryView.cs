using NonFactors.Mvc.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesTerritoryView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public String CountryRegionCode { get; set; }
        public String Group { get; set; }
        public Decimal SalesYtd { get; set; }
        public Decimal SalesLastYear { get; set; }
        public Decimal CostYtd { get; set; }
        public Decimal CostLastYear { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<Customer> Customer { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual List<SalesPerson> SalesPerson { get; set; }
        public virtual List<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public virtual List<StateProvince> StateProvince { get; set; }
    }
}
