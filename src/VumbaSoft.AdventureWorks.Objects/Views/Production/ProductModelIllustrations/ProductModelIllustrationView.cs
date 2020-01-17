using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductModelIllustrationView : BaseView
    {
        public Int32 ProductModelId { get; set; }
        public Int32 IllustrationId { get; set; }
        public String ProductModelTitle { get; set; }
        public String IllustrationTitle { get; set; }

        public virtual Illustration Illustration { get; set; }
        public virtual ProductModel ProductModel { get; set; }
    }
}
