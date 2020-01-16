using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class WorkOrderRoutingsController : ValidatedController<IWorkOrderRoutingValidator, IWorkOrderRoutingService>
    {
        public WorkOrderRoutingsController(IWorkOrderRoutingValidator validator, IWorkOrderRoutingService service)
            : base(validator, service)
        {
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(Service.GetViews());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WorkOrderRoutingView routing)
        {
            if (!Validator.CanCreate(routing))
                return View(routing);

            Service.Create(routing);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<WorkOrderRoutingView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<WorkOrderRoutingView>(id));
        }

        [HttpPost]
        public ActionResult Edit(WorkOrderRoutingView routing)
        {
            if (!Validator.CanEdit(routing))
                return View(routing);

            Service.Edit(routing);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<WorkOrderRoutingView>(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public RedirectToActionResult DeleteConfirmed(Int32 id)
        {
            Service.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
