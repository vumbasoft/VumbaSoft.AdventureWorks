using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContinentRegion : BaseModel
    {
        public string Title { get; set; }
        public Int32 ContinentId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
        public virtual List<Country> Countries { get; set; }
        public virtual Continent Continent { get; set; }
    }
}
