using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Customer : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }
        public int? SalesTerritoryId { get; set; }
        public int? IndividualId { get; set; }
        public int? StoreId { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerType { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual Individual Individual { get; set; }
        public virtual Store Store { get; set; }
        public virtual List<CustomerAddress> CustomerAddress { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
