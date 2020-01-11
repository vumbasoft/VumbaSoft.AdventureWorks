using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class AdventureworkFacility : BaseModel
    {
        public String Title { get; set; }
        public Int32 CityId { get; set; }
        public Int32 TenantId { get; set; }
        public Int32? Population { get; set; }
        public String Remarks { get; set; }
    }
}
