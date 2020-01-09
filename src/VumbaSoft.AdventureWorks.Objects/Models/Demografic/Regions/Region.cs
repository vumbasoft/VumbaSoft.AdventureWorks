using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Region : BaseModel
    {
        public string Title { get; set; }
        public Int32 CountryId { get; set; }
        public Int32? Population { get; set; }
        public string Remarks { get; set; }
        public virtual List<Province> Provinces { get; set; }
        public virtual Country Country { get; set; }
    }
}
