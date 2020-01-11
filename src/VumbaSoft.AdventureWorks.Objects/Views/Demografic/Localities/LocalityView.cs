using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class LocalityView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public Int32 DistrictId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
        public String? DistrictTitle { get; set; }
    }
}
