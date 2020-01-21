using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Individual : BaseModel
    {
        public int CustomerId { get; set; }
        public int ContactId { get; set; }
        public string Demographics { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
