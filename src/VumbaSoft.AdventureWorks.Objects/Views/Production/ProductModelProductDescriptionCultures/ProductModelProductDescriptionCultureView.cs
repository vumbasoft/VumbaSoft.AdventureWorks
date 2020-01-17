using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductModelProductDescriptionCultureView : BaseView
    {
        public String Title { get; set; }
        public Int32 ProductModelId { get; set; }
        public Int32 ProductDescriptionId { get; set; }
        public Int32 CultureId { get; set; }
        public String ProductModelTitle { get; set; }
        public String ProductDescriptionTitle { get; set; }
        public String CultureTitle { get; set; }

        public virtual Culture Culture { get; set; }
        public virtual ProductDescription ProductDescription { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
