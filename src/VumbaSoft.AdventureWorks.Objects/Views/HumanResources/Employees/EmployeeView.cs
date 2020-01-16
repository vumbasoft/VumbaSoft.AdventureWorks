using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class EmployeeView : BaseView
    {
        public String Name { get; set; }
        public String SurnameFirst { get; set; }
        public String SurnameSecond { get; set; }
        public String NationalIdnumber { get; set; }
        public Int32? CompanyId { get; set; }
        public Int32 ContactId { get; set; }
        public String LoginId { get; set; }
        public Int32? ManagerId { get; set; }
        public String Title { get; set; }
        public DateTime BirthDate { get; set; }
        public String MaritalStatus { get; set; }
        public String Gender { get; set; }
        public DateTime HireDate { get; set; }
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? CurrentFlag { get; set; }
        //public string FullName { get { return string.Format("{0} {1} {2}", Name, SurnameFirst, SurnameSecond); } }
        public string FullName => $"{SurnameFirst} {SurnameSecond}, {Name}";

        public String? CompanyTitle { get; set; }
        public String? ContactTitle { get; set; }
        public String? LoginTitle { get; set; }
        public Int32? ManagerTitle { get; set; }
    }
}
