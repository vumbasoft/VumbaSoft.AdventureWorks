using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesTaxRateView : BaseView
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }

        public Int32 SalesTaxRateId { get; set; }
        public Int32 StateProvinceId { get; set; }
        public byte TaxType { get; set; }
        public Decimal TaxRate { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public String SalesTaxRateTitle { get; set; }
        public String StateProvinceTitle { get; set; }

        public virtual StateProvince StateProvince { get; set; }
    }
}
