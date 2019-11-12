using VumbaSoft.AdventureWorks.Objects;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Tests
{
    public class TestView : BaseView
    {
        [StringLength(128)]
        public String? Title { get; set; }
    }
}
