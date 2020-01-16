using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class JobCandidate : BaseModel
    {
        public Int32? EmployeeId { get; set; }
        public String Resume { get; set; }
        public String Remarks { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
