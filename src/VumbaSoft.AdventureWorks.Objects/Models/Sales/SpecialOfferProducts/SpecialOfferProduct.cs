using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class SpecialOfferProduct : BaseModel
    {
        public int SpecialOfferId { get; set; }
        public int ProductId { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual Product Product { get; set; }
        public virtual SpecialOffer SpecialOffer { get; set; }
        public virtual IList<SalesOrderDetail> SalesOrderDetail { get; set; }
    }
}
