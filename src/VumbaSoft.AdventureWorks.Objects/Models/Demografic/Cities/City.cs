using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class City : BaseModel
    {
        public string Title { get; set; }
        public Int32 LocalityId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }

        public virtual List<AdventureworkFacility> AdventureworkFacilities { get; set; }
        public virtual Locality Locality { get; set; }
    }
}
