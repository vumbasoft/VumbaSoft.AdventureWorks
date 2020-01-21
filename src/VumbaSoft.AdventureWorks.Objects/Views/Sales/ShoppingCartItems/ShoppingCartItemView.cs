using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ShoppingCartItemView : BaseView
    {
        public Int32? ShoppingCartId { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Product Product { get; set; }
    }
}
