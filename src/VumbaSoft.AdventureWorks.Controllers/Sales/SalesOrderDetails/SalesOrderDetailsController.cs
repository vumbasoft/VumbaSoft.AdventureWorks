using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SalesOrderDetailsController : ValidatedController<ISalesOrderDetailValidator, ISalesOrderDetailService>
    {
        public SalesOrderDetailsController(ISalesOrderDetailValidator validator, ISalesOrderDetailService service)
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
        public ActionResult Create(SalesOrderDetailView detail)
        {
            if (!Validator.CanCreate(detail))
                return View(detail);

            Service.Create(detail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderDetailView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderDetailView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SalesOrderDetailView detail)
        {
            if (!Validator.CanEdit(detail))
                return View(detail);

            Service.Edit(detail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesOrderDetailView>(id));
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
