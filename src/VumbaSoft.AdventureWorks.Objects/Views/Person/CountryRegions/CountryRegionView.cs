using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CountryRegionView : BaseView
    {
        public string Title { get; set; }
        public string CountryRegionCode { get; set; }
        public String Remarks { get; set; }
    }
}
