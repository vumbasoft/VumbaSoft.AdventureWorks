using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace VumbaSoft.AdventureWorks.Components.Security.Tests
{
    [ExcludeFromCodeCoverage]
    public class NotAttributedController : Controller
    {
        [HttpGet]
        public ViewResult Action()
        {
            return View();
        }
    }
}
