using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Province : BaseModel
    {
        public String Title { get; set; }
        public Int32 RegionId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
        public virtual List<District> Districts { get; set; }
        public virtual Region Region { get; set; }
    }
}
