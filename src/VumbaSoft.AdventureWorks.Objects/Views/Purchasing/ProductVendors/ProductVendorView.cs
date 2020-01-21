using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductVendorView : BaseView
    {
        public Int32 ProductId { get; set; }
        public Int32 VendorId { get; set; }
        public Int32 UnitMeasureId { get; set; }
        public Int32 AverageLeadTime { get; set; }
        public decimal StandardPrice { get; set; }
        //TODO: Review the decimal nullable value
        public decimal? LastReceiptCost { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public Int32 MinOrderQty { get; set; }
        public Int32 MaxOrderQty { get; set; }
        public Int32? OnOrderQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        public String ProductTitle { get; set; }
        public String VendorTitle { get; set; }
        public String UnitMeasureTitle { get; set; }

        public virtual Product Product { get; set; }
        public virtual UnitMeasure UnitMeasure { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
