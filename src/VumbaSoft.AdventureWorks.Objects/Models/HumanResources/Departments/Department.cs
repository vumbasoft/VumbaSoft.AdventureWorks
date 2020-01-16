using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Department : BaseModel
    {
        public String Title { get; set; }
        public String GroupName { get; set; }
        public Int32? TenantId { get; set; }

        public virtual List<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
    }
}
