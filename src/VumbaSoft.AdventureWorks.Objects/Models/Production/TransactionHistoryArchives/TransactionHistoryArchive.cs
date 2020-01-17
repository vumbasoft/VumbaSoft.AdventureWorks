using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class TransactionHistoryArchive : BaseModel
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
    }
}
