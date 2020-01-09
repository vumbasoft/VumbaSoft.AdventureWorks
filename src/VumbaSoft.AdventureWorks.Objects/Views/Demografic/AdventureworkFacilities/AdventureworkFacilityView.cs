using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class AdventureworkFacilityView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public string Title { get; set; }
        public Int32 CityId { get; set; }
        public Int32 TenantId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }

    }
}
