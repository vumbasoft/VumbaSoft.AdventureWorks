using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class StateProvince : BaseModel
    {
        public String Title { get; set; }
        public String StateProvinceCode { get; set; }
        public String CountryRegionCode { get; set; }
        public Boolean? IsOnlyStateProvinceFlag { get; set; }
        public int TerritoryId { get; set; }
        public String Remarks { get; set; }

        public virtual List<Address> Address { get; set; }
        public virtual CountryRegion CountryRegion { get; set; }
        public virtual SalesTerritory SalesTerritory { get; set; }
        public virtual List<SalesTaxRate> SalesTaxRate { get; set; }
    }
}
