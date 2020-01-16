using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Shift : BaseModel
    {
        public String Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Remarks { get; set; }

        public virtual List<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
