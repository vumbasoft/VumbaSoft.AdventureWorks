using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class EmployeeAddress : BaseModel
    {
        public Int32 EmployeeId { get; set; }
        public Int32 AddressId { get; set; }
        public String Remarks { get; set; }
        public virtual Address Address { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
