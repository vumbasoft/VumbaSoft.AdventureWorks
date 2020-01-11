using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProvinceView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public Int32 RegionId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
        public String? RegionTitle { get; set; }
    }
}
