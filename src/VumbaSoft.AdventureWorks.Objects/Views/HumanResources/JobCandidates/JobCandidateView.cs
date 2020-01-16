using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class JobCandidateView : BaseView
    {
        public Int32? EmployeeId { get; set; }
        public String Resume { get; set; }
    }
}
