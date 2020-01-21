using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Store : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }

        public Int32 CustomerId { get; set; }
        public Int32? SalesPersonId { get; set; }
        public String Demographics { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual List<StoreContact> StoreContact { get; set; }
    }
}
