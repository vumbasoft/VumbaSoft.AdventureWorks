using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.HumanResources
{
    [Area("HumanResources")]
    public class EmployeePayHistoriesController : ValidatedController<IEmployeepayhistoryValidator, IEmployeepayhistoryService>
    {
        public EmployeePayHistoriesController(IEmployeepayhistoryValidator validator, IEmployeepayhistoryService service)
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
        public ActionResult Create(EmployeePayHistoryView employeepayhistory)
        {
            if (!Validator.CanCreate(employeepayhistory))
                return View(employeepayhistory);

            Service.Create(employeepayhistory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeePayHistoryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeePayHistoryView>(id));
        }

        [HttpPost]
        public ActionResult Edit(EmployeePayHistoryView employeepayhistory)
        {
            if (!Validator.CanEdit(employeepayhistory))
                return View(employeepayhistory);

            Service.Edit(employeepayhistory);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<EmployeePayHistoryView>(id));
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
