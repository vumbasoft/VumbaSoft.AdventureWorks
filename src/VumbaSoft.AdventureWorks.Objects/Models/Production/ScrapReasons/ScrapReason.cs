using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ScrapReason : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }

        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<WorkOrder> WorkOrder { get; set; }
    }
}
