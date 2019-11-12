using VumbaSoft.AdventureWorks.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Tests
{
    public class TestModel : BaseModel
    {
        [StringLength(128)]
        public String? Title { get; set; }
    }
}
