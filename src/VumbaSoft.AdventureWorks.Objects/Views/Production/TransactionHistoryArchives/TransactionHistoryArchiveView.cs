using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class TransactionHistoryArchiveView : BaseView
    {
        public Int32 TransactionId { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 ReferenceOrderId { get; set; }
        public Int32 ReferenceOrderLineId { get; set; }
        public DateTime TransactionDate { get; set; }
        [StringLength(128)]
        public String TransactionType { get; set; }
        public Int32 Quantity { get; set; }
        public decimal ActualCost { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public String TransactionTitle { get; set; }
        public String ProductTitle { get; set; }
        public String ReferenceOrderTitle { get; set; }
        public String ReferenceOrderLineTitle { get; set; }
    }
}
