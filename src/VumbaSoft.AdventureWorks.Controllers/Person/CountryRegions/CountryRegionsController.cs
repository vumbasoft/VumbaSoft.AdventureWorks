using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Person
{
    [Area("Person")]
    public class CountryRegionsController : ValidatedController<ICountryRegionValidator, ICountryRegionService>
    {
        public CountryRegionsController(ICountryRegionValidator validator, ICountryRegionService service)
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
        public ActionResult Create(CountryRegionView region)
        {
            if (!Validator.CanCreate(region))
                return View(region);

            Service.Create(region);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionView>(id));
        }

        [HttpPost]
        public ActionResult Edit(CountryRegionView region)
        {
            if (!Validator.CanEdit(region))
                return View(region);

            Service.Edit(region);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CountryRegionView>(id));
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
