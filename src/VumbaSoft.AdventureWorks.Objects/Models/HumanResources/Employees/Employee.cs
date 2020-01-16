using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Employee : BaseModel
    {
        public String Name { get; set; }
        public String SurnameFirst { get; set; }
        public String SurnameSecond { get; set; }
        public Int32? TenantId { get; set; }
        public String NationalIdnumber { get; set; }
        public Int32 ContactId { get; set; }
        public String LoginId { get; set; }
        public Int32? ManagerId { get; set; }
        public String Title { get; set; }
        public DateTime BirthDate { get; set; }
        public String MaritalStatus { get; set; }
        public String Gender { get; set; }
        public DateTime HireDate { get; set; }
        public Boolean? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public Boolean? CurrentFlag { get; set; }
        public String Remarks { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual List<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual List<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public virtual List<EmployeePayHistory> EmployeePayHistory { get; set; }
        public virtual List<Employee> InverseManager { get; set; }
        public virtual List<JobCandidate> JobCandidate { get; set; }
        public virtual List<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    }
}
