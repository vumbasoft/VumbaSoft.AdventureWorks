using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesOrderHeaderSalesReasonView : BaseView
    {
        public int SalesOrderId { get; set; }
        public int SalesReasonId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
        public virtual SalesReason SalesReason { get; set; }
    }
}
