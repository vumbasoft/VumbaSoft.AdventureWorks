using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class CustomCareType : BaseModel
    {
        public string Title { get; set; }
        public string Remarks { get; set; }
    }
}
