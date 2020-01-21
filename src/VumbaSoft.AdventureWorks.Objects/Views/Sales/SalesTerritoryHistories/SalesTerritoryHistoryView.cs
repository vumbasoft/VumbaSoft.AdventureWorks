using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SalesTerritoryHistoryView : BaseView
    {
        public Int32 SalesPersonId { get; set; }
        public Int32 SalesTerritoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual SalesPerson SalesPerson { get; set; }
        public virtual SalesTerritory SalesTerritory { get; set; }
    }
}
