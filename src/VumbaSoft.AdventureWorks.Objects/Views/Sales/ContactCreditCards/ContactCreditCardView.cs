using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContactCreditCardView : BaseView
    {
        public Int32 ContactId { get; set; }
        public Int32 CreditCardId { get; set; }
        public String ContactTitle { get; set; }
        public String CreditCardTitle { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
