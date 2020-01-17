using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductListPriceHistoryView : BaseView
    {
        public Int32 ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal ListPrice { get; set; }
        public String ProductTitle { get; set; }

        public virtual Product Product { get; set; }
    }
}
