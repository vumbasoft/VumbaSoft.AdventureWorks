using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CultureView : BaseView
    {

        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String Title { get; set; }
        [StringLength(2)]
        public String ISO2 { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
    }
}
