using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesReason : BaseModel
    {
        [Required]
        [StringLength(128)]
        public String Title { get; set; }

        [StringLength(256)]
        public String ReasonType { get; set; }
        public String Remarks { get; set; }

        public virtual List<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
    }
}
