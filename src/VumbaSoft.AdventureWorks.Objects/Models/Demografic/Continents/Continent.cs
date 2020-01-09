using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Continent : BaseModel
    {
        public string Title { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
        public virtual List<ContinentRegion> ContinentRegions { get; set; }
    }
}
