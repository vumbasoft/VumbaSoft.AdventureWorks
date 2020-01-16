using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductCostHistory : BaseModel
    {
        public Int32 ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Decimal StandardCost { get; set; }

        public virtual Product Product { get; set; }
    }
}
