using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class AddressView : BaseView
    {
        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String City { get; set; }
        public int StateProvinceId { get; set; }
        public String PostalCode { get; set; }
        public String Remarks { get; set; }
        public int StateProvinceTitle { get; set; }
    }
}
