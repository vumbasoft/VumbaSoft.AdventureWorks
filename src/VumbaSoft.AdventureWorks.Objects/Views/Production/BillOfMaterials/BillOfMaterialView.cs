using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class BillOfMaterialView : BaseView
    {
        public Int32? ProductAssemblyId { get; set; }
        public Int32 ProductComponentId { get; set; }
        public String UnitMeasureId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short Bomlevel { get; set; }
        public decimal PerAssemblyQty { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public String UnitMeasureTitle { get; set; }
        public String? ProductAssemblyTitle { get; set; }
        public String ComponentTitle { get; set; }

        public virtual Product Component { get; set; }
        public virtual Product ProductAssembly { get; set; }
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}
