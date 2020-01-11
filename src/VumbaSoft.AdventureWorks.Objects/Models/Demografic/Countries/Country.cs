using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Country : BaseModel
    {
        public String Title { get; set; }
        public Int32 ContinentRegionId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
        public virtual List<Region> Regions { get; set; }
        public virtual ContinentRegion ContinentRegion { get; set; }
    }
}
