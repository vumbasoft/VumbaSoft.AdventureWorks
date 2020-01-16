using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductDescription : BaseModel
    {
        [StringLength(128)]
        public String Title { get; set; }
        public String Remarks { get; set; }

        public virtual List<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }
}
