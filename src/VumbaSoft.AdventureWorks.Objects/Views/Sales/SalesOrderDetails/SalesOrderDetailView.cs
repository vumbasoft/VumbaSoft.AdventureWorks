using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesOrderDetailView : BaseView
    {
        public Int32 ProductId { get; set; }
        public Int32 SalesOrderId { get; set; }
        public Int32 SpecialOfferId { get; set; }
        public String CarrierTrackingNumber { get; set; }
        public Int16 OrderQty { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal UnitPriceDiscount { get; set; }
        public Decimal LineTotal { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public String ProductTitle { get; set; }
        public String SalesOrderTitle { get; set; }
        public String SpecialOfferTitle { get; set; }

        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
        public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }
    }
}
