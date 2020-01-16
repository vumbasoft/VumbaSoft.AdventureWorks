using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class DocumentView : BaseView
    {
        public String Title { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        public String Revision { get; set; }
        public int ChangeNumber { get; set; }
        public byte Status { get; set; }
        public String DocumentSummary { get; set; }
        public byte[] Document1 { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<ProductDocument> ProductDocument { get; set; }
    }
}
