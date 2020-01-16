using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductDocument : BaseModel
    {
        public Int32 ProductId { get; set; }
        public Int32 DocumentId { get; set; }
        public String Remarks { get; set; }

        public virtual Document Document { get; set; }
        public virtual Product Product { get; set; }
    }
}
