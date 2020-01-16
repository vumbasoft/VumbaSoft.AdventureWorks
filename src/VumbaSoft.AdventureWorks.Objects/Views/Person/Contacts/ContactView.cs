using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContactView : BaseView
    {
        public Boolean NameStyle { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Suffix { get; set; }
        public String EmailAddress { get; set; }
        public Int32 EmailPromotion { get; set; }
        public String Phone { get; set; }
        public String PasswordHash { get; set; }
        public String PasswordSalt { get; set; }
        public String AdditionalContactInfo { get; set; }
        public String Remarks { get; set; }
    }
}
