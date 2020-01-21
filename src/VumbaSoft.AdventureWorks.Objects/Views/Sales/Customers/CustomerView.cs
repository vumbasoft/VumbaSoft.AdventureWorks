using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CustomerView : BaseView
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }
        public Int32? SalesTerritoryId { get; set; }
        public Int32? IndividualId { get; set; }
        public Int32? StoreId { get; set; }
        public String AccountNumber { get; set; }
        public String CustomerType { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public String? SalesTerritoryTitle { get; set; }
        public String? IndividualTitle { get; set; }
        public String? StoreTitle { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual Store Store { get; set; }
        public virtual List<CustomerAddress> CustomerAddress { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
