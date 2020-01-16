using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class Contact : BaseModel
    {
        public bool NameStyle { get; set; }
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

        public virtual List<ContactCreditCard> ContactCreditCard { get; set; }
        public virtual List<Employee> Employee { get; set; }
        public virtual List<Individual> Individual { get; set; }
        public virtual List<SalesOrderHeader> SalesOrderHeader { get; set; }
        public virtual List<StoreContact> StoreContact { get; set; }
        public virtual List<VendorContact> VendorContact { get; set; }

    }
}
