using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class District : BaseModel
    {
        public String Title { get; set; }
        public Int32 ProvinceId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
        public virtual List<Locality> Localities { get; set; }
        public virtual Province Province { get; set; }
    }
}
