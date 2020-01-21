using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class StoreContact : BaseModel
    {
        public Int32 CustomerId { get; set; }
        public Int32 ContactId { get; set; }
        public Int32 ContactTypeId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Store Customer { get; set; }
    }
}
