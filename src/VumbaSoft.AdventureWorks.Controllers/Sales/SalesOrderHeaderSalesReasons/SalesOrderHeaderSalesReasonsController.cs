using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SalesOrderHeaderSalesReasonsController : ValidatedController<ISalesOrderHeaderSalesReasonValidator, ISalesOrderHeaderSalesReasonService>
    {
        public SalesOrderHeaderSalesReasonsController(ISalesOrderHeaderSalesReasonValidator validator, ISalesOrderHeaderSalesReasonService service)
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
        public ActionResult Create(SalesOrderHeaderSalesReasonView reason)
        {
            if (!Validator.CanCreate(reason))
                return View(reason);

            Service.Create(reason);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderSalesReasonView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderSalesReasonView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SalesOrderHeaderSalesReasonView reason)
        {
            if (!Validator.CanEdit(reason))
                return View(reason);

            Service.Edit(reason);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderHeaderSalesReasonView>(id));
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
