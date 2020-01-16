using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Illustration : BaseModel
    {
        [StringLength(128)]
        public String Title { get; set; }
        public String Diagram { get; set; }
         public String Remarks { get; set; }

        public virtual List<ProductModelIllustration> ProductModelIllustration { get; set; }
    }
}
