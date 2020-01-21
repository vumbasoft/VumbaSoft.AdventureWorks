using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CustomerAddressView : BaseView
    {
        public Int32 CustomerId { get; set; }
        public Int32 AddressId { get; set; }
        public Int32 AddressTypeId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public String CustomerTitle { get; set; }
        public String AddressTitle { get; set; }
        public String AddressTypeTitle { get; set; }

        public virtual Address Address { get; set; }
        public virtual Addresstype AddressType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
