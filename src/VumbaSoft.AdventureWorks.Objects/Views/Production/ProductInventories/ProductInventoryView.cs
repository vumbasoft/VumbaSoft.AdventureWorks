using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductInventoryView : BaseView
    {
        public Int32 ProductId { get; set; }
        public short LocationId { get; set; }
        public String Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public String Remarks { get; set; }
        public String ProductTitle { get; set; }
        public String LocationTitle { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
