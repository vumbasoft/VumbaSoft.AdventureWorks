using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContactType : BaseModel
    {
        public String Title { get; set; }
        public String Remarks { get; set; }
        public virtual List<StoreContact> StoreContact { get; set; }
        public virtual List<VendorContact> VendorContact { get; set; }

    }
}
