using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Purchasing
{
    [Area("Purchasing")]
    public class PurchaseOrderHeadersController : ValidatedController<IPurchaseOrderHeaderValidator, IPurchaseOrderHeaderService>
    {
        public PurchaseOrderHeadersController(IPurchaseOrderHeaderValidator validator, IPurchaseOrderHeaderService service)
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
        public ActionResult Create(PurchaseOrderHeaderView header)
        {
            if (!Validator.CanCreate(header))
                return View(header);

            Service.Create(header);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderHeaderView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderHeaderView>(id));
        }

        [HttpPost]
        public ActionResult Edit(PurchaseOrderHeaderView header)
        {
            if (!Validator.CanEdit(header))
                return View(header);

            Service.Edit(header);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<PurchaseOrderHeaderView>(id));
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
