using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class VendorAddress : BaseModel
    {
        public Int32 VendorId { get; set; }
        public Int32 AddressId { get; set; }
        public Int32 AddressTypeId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Address Address { get; set; }
        public virtual Addresstype AddressType { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
