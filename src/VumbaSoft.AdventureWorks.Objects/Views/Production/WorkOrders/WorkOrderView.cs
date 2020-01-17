using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class WorkOrderView : BaseView
    {
        public Int32 ProductId { get; set; }
        public Int32 OrderQty { get; set; }
        public Int32 StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public Int32? ScrapReasonId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ScrapReason ScrapReason { get; set; }
        public virtual List<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
