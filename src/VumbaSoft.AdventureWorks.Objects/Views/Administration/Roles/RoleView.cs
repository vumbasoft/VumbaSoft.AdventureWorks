﻿using VumbaSoft.AdventureWorks.Components.Extensions;
using NonFactors.Mvc.Lookup;
using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class RoleView : BaseView
    {
        [Required]
        [LookupColumn]
        [StringLength(128)]
        public String? Title { get; set; }

        public MvcTree Permissions { get; set; }

        public RoleView()
        {
            Permissions = new MvcTree();
        }
    }
}
