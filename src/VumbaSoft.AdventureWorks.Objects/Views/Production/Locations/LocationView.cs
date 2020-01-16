using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class LocationView : BaseView
    {
        public String Title { get; set; }
        public Decimal CostRate { get; set; }
        public Decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<ProductInventory> ProductInventory { get; set; }
        public virtual List<WorkOrderRouting> WorkOrderRouting { get; set; }
    }
}
