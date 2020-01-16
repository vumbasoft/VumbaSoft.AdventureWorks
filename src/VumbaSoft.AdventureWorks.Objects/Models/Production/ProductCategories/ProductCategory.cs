using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductCategory : BaseModel
    {
        public String Title { get; set; }
        public String Remarks { get; set; }

        public virtual List<ProductSubcategory> ProductSubcategory { get; set; }
    }
}
