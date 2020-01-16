using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Address : BaseModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }
        public String Remarks { get; set; }
        //public Guid Rowguid { get; set; }
        //public DateTime ModifiedDate { get; set; }

        public virtual StateProvince StateProvince { get; set; }
        public virtual List<CustomerAddress> CustomerAddress { get; set; }
        public virtual List<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeaderBillToAddress { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeaderShipToAddress { get; set; }
        public virtual List<VendorAddress> VendorAddress { get; set; }
    }
}
