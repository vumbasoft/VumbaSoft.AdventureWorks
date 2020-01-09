using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class DistrictView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public string Title { get; set; }
        public Int32 ProvinceId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
    }
}