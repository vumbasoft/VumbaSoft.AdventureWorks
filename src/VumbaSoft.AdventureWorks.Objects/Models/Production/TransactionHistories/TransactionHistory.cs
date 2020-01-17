using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class TransactionHistory : BaseModel
    {
        public Int32 ProductId { get; set; }
        public Int32 ReferenceOrderId { get; set; }
        public Int32 ReferenceOrderLineId { get; set; }
        public DateTime TransactionDate { get; set; }
        public String TransactionType { get; set; }
        public Int32 Quantity { get; set; }
        public decimal ActualCost { get; set; }

        public virtual Product Product { get; set; }
    }
}
