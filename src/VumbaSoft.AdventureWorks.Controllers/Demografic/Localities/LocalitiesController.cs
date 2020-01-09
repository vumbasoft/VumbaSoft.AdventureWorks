using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Demografic
{
    [Area("Demografic")]
    public class LocalitiesController : ValidatedController<ILocalityValidator, ILocalityService>
    {
        public LocalitiesController(ILocalityValidator validator, ILocalityService service)
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
        public ActionResult Create(LocalityView locality)
        {
            if (!Validator.CanCreate(locality))
                return View(locality);

            Service.Create(locality);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<LocalityView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<LocalityView>(id));
        }

        [HttpPost]
        public ActionResult Edit(LocalityView locality)
        {
            if (!Validator.CanEdit(locality))
                return View(locality);

            Service.Edit(locality);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<LocalityView>(id));
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
