using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Addresstype : BaseModel
    {
        public String Title { get; set; }
        public String Remarks { get; set; }

        public virtual List<CustomerAddress> CustomerAddress { get; set; }
        public virtual List<VendorAddress> VendorAddress { get; set; }
    }
}
