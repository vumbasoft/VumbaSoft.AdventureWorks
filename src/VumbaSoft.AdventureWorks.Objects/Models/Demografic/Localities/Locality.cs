using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Locality : BaseModel
    {
        public string Title { get; set; }
        public Int32 DistrictId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
        public virtual List<City> Cities { get; set; }
        public virtual District District { get; set; }
    }
}
