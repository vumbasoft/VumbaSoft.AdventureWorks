using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ShipMethod : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }
        public Decimal ShipBase { get; set; }
        public Decimal ShipRate { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
