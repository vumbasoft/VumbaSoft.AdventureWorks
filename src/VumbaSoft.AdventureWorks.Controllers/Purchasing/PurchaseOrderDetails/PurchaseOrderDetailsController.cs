using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Purchasing
{
    [Area("Purchasing")]
    public class PurchaseOrderDetailsController : ValidatedController<IPurchaseOrderDetailValidator, IPurchaseOrderDetailService>
    {
        public PurchaseOrderDetailsController(IPurchaseOrderDetailValidator validator, IPurchaseOrderDetailService service)
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
        public ActionResult Create(PurchaseOrderDetailView detail)
        {
            if (!Validator.CanCreate(detail))
                return View(detail);

            Service.Create(detail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderDetailView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderDetailView>(id));
        }

        [HttpPost]
        public ActionResult Edit(PurchaseOrderDetailView detail)
        {
            if (!Validator.CanEdit(detail))
                return View(detail);

            Service.Edit(detail);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderDetailView>(id));
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
