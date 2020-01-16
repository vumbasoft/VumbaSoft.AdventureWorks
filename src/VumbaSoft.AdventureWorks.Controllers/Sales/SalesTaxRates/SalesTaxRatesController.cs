using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class SalesTaxRatesController : ValidatedController<ISalesTaxRateValidator, ISalesTaxRateService>
    {
        public SalesTaxRatesController(ISalesTaxRateValidator validator, ISalesTaxRateService service)
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
        public ActionResult Create(SalesTaxRateView rate)
        {
            if (!Validator.CanCreate(rate))
                return View(rate);

            Service.Create(rate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTaxRateView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTaxRateView>(id));
        }

        [HttpPost]
        public ActionResult Edit(SalesTaxRateView rate)
        {
            if (!Validator.CanEdit(rate))
                return View(rate);

            Service.Edit(rate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<SalesTaxRateView>(id));
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
