﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VumbaSoft.AdventureWorks.Objects
{
    public class AccountEditView : BaseView
    {
        [Required]
        [StringLength(32)]
        public String? Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public String? Email { get; set; }

        public Boolean IsLocked { get; set; }

        public Int32? RoleId { get; set; }
    }
}
