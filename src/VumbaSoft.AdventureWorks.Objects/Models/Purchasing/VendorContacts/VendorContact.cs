using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class VendorContact : BaseModel
    {
        public Int32 VendorId { get; set; }
        public Int32 ContactId { get; set; }
        public Int32 ContactTypeId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
