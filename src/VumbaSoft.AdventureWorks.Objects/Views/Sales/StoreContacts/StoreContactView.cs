using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class StoreContactView : BaseView
    {
        public Int32 CustomerId { get; set; }
        public Int32 ContactId { get; set; }
        public Int32 ContactTypeId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }
        public Int32 CustomerTitle { get; set; }
        public Int32 ContactTitle { get; set; }
        public Int32 ContactTypeTitle { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Store Customer { get; set; }
    }
}
