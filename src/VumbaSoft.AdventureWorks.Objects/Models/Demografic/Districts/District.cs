using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class District : BaseModel
    {
        public string Title { get; set; }
        public Int32 ProvinceId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
        public virtual List<Locality> Localities { get; set; }
        public virtual Province Province { get; set; }
    }
}
