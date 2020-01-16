using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductInventory : BaseModel
    {
        public Int32 ProductId { get; set; }
        public short LocationId { get; set; }
        public String Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public String Remarks { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
