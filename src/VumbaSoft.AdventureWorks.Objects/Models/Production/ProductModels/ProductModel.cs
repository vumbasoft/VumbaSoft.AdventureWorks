using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductModel : BaseModel
    {
        public String Title { get; set; }
        public String CatalogDescription { get; set; }
        public String Instructions { get; set; }

        public virtual List<Product> Product { get; set; }
        public virtual List<ProductModelIllustration> ProductModelIllustration { get; set; }
        public virtual List<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
    }
}
