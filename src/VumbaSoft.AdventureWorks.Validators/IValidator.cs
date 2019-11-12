using Microsoft.AspNetCore.Mvc.ModelBinding;
using VumbaSoft.AdventureWorks.Components.Notifications;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IValidator : IDisposable
    {
        ModelStateDictionary ModelState { get; set; }
        Int32 CurrentAccountId { get; set; }
        Alerts Alerts { get; set; }
    }
}
