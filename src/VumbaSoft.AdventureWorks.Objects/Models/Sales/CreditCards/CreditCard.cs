using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CreditCard : BaseModel
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        [StringLength(256)]
        public String Remarks { get; set; }

        public virtual List<ContactCreditCard> ContactCreditCard { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
