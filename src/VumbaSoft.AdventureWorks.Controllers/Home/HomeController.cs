﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Components.Notifications;
using VumbaSoft.AdventureWorks.Components.Security;
using VumbaSoft.AdventureWorks.Resources;
using VumbaSoft.AdventureWorks.Services;

namespace VumbaSoft.AdventureWorks.Controllers
{
    [AllowUnauthorized]
    public class HomeController : ServicedController<IAccountService>
    {
        public HomeController(IAccountService service)
            : base(service)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (!Service.IsActive(CurrentAccountId))
                return RedirectToAction("Logout", "Auth");

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Error()
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                Alerts.Add(new Alert
                {
                    Id = "SystemError",
                    Type = AlertType.Danger,
                    Message = Resource.ForString("SystemError")
                });

                return Json(new { alerts = Alerts });
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("[controller]/not-found")]
        public new ActionResult NotFound()
        {
            if (Service.IsLoggedIn(User) && !Service.IsActive(CurrentAccountId))
                return RedirectToAction("Logout", "Auth");

            Response.StatusCode = StatusCodes.Status404NotFound;

            return View();
        }
    }
}
