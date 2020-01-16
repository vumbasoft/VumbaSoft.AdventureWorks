using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ContactTypeView : BaseView
    {
        public String Title { get; set; }
        public String Remarks { get; set; }
    }
}
