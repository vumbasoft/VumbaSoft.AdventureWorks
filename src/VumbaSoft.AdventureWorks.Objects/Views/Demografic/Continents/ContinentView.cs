using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContinentView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
    }
}
