using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace VumbaSoft.AdventureWorks.Components.Security.Tests
{
    [ExcludeFromCodeCoverage]
    public class InheritedAuthorizedController : AuthorizedController
    {
        [HttpGet]
        public ViewResult InheritanceAction()
        {
            return View();
        }
    }
}
