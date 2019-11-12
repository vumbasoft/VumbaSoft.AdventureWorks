using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace VumbaSoft.AdventureWorks.Components.Security.Tests
{
    [ExcludeFromCodeCoverage]
    public class InheritedAllowUnauthorizedController : AllowUnauthorizedController
    {
        [HttpGet]
        public ViewResult InheritanceAction()
        {
            return View();
        }
    }
}
