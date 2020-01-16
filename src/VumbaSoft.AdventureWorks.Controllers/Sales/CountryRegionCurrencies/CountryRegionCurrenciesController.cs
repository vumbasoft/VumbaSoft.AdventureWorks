using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class CountryRegionCurrenciesController : ValidatedController<ICountryRegionCurrencyValidator, ICountryRegionCurrencyService>
    {
        public CountryRegionCurrenciesController(ICountryRegionCurrencyValidator validator, ICountryRegionCurrencyService service)
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
        public ActionResult Create(CountryRegionCurrencyView currency)
        {
            if (!Validator.CanCreate(currency))
                return View(currency);

            Service.Create(currency);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionCurrencyView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionCurrencyView>(id));
        }

        [HttpPost]
        public ActionResult Edit(CountryRegionCurrencyView currency)
        {
            if (!Validator.CanEdit(currency))
                return View(currency);

            Service.Edit(currency);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionCurrencyView>(id));
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
