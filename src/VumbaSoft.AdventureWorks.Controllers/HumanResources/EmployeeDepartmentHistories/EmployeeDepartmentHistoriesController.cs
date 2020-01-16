using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.HumanResources
{
    [Area("HumanResources")]
    public class EmployeeDepartmentHistoriesController : ValidatedController<IEmployeedepartmenthistoryValidator, IEmployeedepartmenthistoryService>
    {
        public EmployeeDepartmentHistoriesController(IEmployeedepartmenthistoryValidator validator, IEmployeedepartmenthistoryService service)
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
        public ActionResult Create(EmployeeDepartmentHistoryView employeedepartmenthistory)
        {
            if (!Validator.CanCreate(employeedepartmenthistory))
                return View(employeedepartmenthistory);

            Service.Create(employeedepartmenthistory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeeDepartmentHistoryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeeDepartmentHistoryView>(id));
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDepartmentHistoryView employeedepartmenthistory)
        {
            if (!Validator.CanEdit(employeedepartmenthistory))
                return View(employeedepartmenthistory);

            Service.Edit(employeedepartmenthistory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeeDepartmentHistoryView>(id));
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
