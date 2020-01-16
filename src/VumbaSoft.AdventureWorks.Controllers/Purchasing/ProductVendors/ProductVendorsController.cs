using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Purchasing
{
    [Area("Purchasing")]
    public class ProductVendorsController : ValidatedController<IProductVendorValidator, IProductVendorService>
    {
        public ProductVendorsController(IProductVendorValidator validator, IProductVendorService service)
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
        public ActionResult Create(ProductVendorView vendor)
        {
            if (!Validator.CanCreate(vendor))
                return View(vendor);

            Service.Create(vendor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductVendorView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductVendorView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductVendorView vendor)
        {
            if (!Validator.CanEdit(vendor))
                return View(vendor);

            Service.Edit(vendor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductVendorView>(id));
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
