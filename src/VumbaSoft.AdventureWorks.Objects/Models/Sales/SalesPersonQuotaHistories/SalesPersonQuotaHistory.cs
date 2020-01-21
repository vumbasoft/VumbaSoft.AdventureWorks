using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesPersonQuotaHistory : BaseModel
    {
        public Int32 SalesPersonId { get; set; }
        public DateTime QuotaDate { get; set; }
        public Decimal SalesQuota { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }
    }
}
