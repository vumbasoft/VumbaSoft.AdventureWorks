using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductSubcategory : BaseModel
    {

        [Required]
        [StringLength(128)]
        public String Title { get; set; }

        [StringLength(256)]
        public String Remarks { get; set; }

        public int ProductCategoryId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
