using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SalesTerritoryHistoriesController : ValidatedController<ISalesTerritoryHistoryValidator, ISalesTerritoryHistoryService>
    {
        public SalesTerritoryHistoriesController(ISalesTerritoryHistoryValidator validator, ISalesTerritoryHistoryService service)
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
        public ActionResult Create(SalesTerritoryHistoryView history)
        {
            if (!Validator.CanCreate(history))
                return View(history);

            Service.Create(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTerritoryHistoryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTerritoryHistoryView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SalesTerritoryHistoryView history)
        {
            if (!Validator.CanEdit(history))
                return View(history);

            Service.Edit(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTerritoryHistoryView>(id));
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
