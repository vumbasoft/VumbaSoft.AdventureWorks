using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class PurchaseOrderDetailView : BaseView
    {
        public Int32 PurchaseOrderHeaderId { get; set; }
        public virtual PurchaseOrderHeader PurchaseOrder { get; set; }

        public Int32 ProductId { get; set; }
        public virtual Product Product { get; set; }

        public DateTime DueDate { get; set; }
        public Int16 OrderQty { get; set; }
        //TODO: Review decimal nulable Exception
        public Decimal UnitPrice { get; set; }
        public Decimal LineTotal { get; set; }
        public Decimal ReceivedQty { get; set; }
        public Decimal RejectedQty { get; set; }
        public Decimal StockedQty { get; set; }
        public String PurchaseOrderHeaderTitle { get; set; }
        public String ProductTitle { get; set; }

    }
}
