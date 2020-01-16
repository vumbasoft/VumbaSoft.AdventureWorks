using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SpecialOfferProductsController : ValidatedController<ISpecialOfferProductValidator, ISpecialOfferProductService>
    {
        public SpecialOfferProductsController(ISpecialOfferProductValidator validator, ISpecialOfferProductService service)
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
        public ActionResult Create(SpecialOfferProductView product)
        {
            if (!Validator.CanCreate(product))
                return View(product);

            Service.Create(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SpecialOfferProductView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SpecialOfferProductView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SpecialOfferProductView product)
        {
            if (!Validator.CanEdit(product))
                return View(product);

            Service.Edit(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SpecialOfferProductView>(id));
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
