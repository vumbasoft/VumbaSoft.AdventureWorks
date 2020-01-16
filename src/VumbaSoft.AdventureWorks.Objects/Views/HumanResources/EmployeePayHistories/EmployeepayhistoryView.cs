using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class EmployeePayHistoryView : BaseView
    {
        public Int32 EmployeeId { get; set; }
        public DateTime RateChangeDate { get; set; }

        [Range(0, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public String EmployeeTitle { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
