using NonFactors.Mvc.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SpecialOfferView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public Decimal DiscountPct { get; set; }
        public String Type { get; set; }
        public String Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 MinQty { get; set; }
        public Int32? MaxQty { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<SpecialOfferProduct> SpecialOfferProduct { get; set; }
    }
}
