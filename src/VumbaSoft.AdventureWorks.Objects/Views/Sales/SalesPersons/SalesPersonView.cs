using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesPersonView : BaseView
    {
        public Int32? TerritoryId { get; set; }
        public Int32? SalesTerritoryId { get; set; }
        public Decimal? SalesQuota { get; set; }
        public Decimal Bonus { get; set; }
        public Decimal CommissionPct { get; set; }
        public Decimal SalesYtd { get; set; }
        public Decimal SalesLastYear { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public String? TerritoryTitle { get; set; }
        public String? SalesTerritoryTitle { get; set; }

        public virtual Employee SalesPersonNavigation { get; set; }
        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual List<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
        public virtual List<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public virtual List<Store> Store { get; set; }
    }
}
