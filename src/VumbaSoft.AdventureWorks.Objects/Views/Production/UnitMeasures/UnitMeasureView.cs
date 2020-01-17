using NonFactors.Mvc.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class UnitMeasureView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public String UnitMeasureCode { get; set; }

        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<BillOfMaterial> BillOfMaterials { get; set; }
        public virtual List<Product> ProductSizeUnitMeasureCodeNavigation { get; set; }
        public virtual List<ProductVendor> ProductVendor { get; set; }
        public virtual List<Product> ProductWeightUnitMeasureCodeNavigation { get; set; }
    }
}
