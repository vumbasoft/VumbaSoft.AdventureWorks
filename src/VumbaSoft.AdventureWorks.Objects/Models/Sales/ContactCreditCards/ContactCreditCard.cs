using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContactCreditCard : BaseModel
    {
        public Int32 ContactId { get; set; }
        public Int32 CreditCardId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
