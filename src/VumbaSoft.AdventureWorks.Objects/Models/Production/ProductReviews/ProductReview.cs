using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductReview : BaseModel
    {
        public Int32 ProductId { get; set; }
        public String ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public String EmailAddress { get; set; }
        public Int32 Rating { get; set; }
        public String Remarks { get; set; }

        public virtual Product Product { get; set; }
    }
}
