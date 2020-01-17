using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class ProductProductPhoto : BaseModel
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ProductPhotoId { get; set; }
        public virtual ProductPhoto ProductPhoto { get; set; }

        public bool Primary { get; set; }        
    }
}
