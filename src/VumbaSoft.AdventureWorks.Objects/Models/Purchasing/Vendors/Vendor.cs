using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Vendor : BaseModel
    {
        public String AccountNumber { get; set; }
        public String Name { get; set; }
        public byte CreditRating { get; set; }
        public Boolean? PreferredVendorStatus { get; set; }
        public Boolean? ActiveFlag { get; set; }
        public String PurchasingWebServiceUrl { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<ProductVendor> ProductVendor { get; set; }
        public virtual List<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public virtual List<VendorAddress> VendorAddress { get; set; }
        public virtual List<VendorContact> VendorContact { get; set; }
    }
}
