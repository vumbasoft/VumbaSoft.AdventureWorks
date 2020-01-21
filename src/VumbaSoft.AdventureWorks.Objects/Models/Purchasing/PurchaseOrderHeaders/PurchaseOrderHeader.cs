using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class PurchaseOrderHeader : BaseModel
    {
        public Int32 EmployeeId { get; set; }
        public Int32 VendorId { get; set; }
        public Int32 ShipMethodId { get; set; }
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal TaxAmt { get; set; }
        public Decimal Freight { get; set; }
        public Decimal TotalDue { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ShipMethod ShipMethod { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual List<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
