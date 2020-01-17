using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductModelView : BaseView
    {
        public String Title { get; set; }
        public String CatalogDescription { get; set; }
        public String Instructions { get; set; }
    }
}
