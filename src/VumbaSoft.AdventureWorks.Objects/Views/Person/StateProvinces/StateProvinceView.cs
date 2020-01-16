using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class StateProvinceView : BaseView
    {
        public String Title { get; set; }
        public String StateProvinceCode { get; set; }
        public String CountryRegionCode { get; set; }
        public Boolean? IsOnlyStateProvinceFlag { get; set; }
        public Int32 TerritoryId { get; set; }
        public String Remarks { get; set; }
        public String TerritoryTitle { get; set; }
    }
}
