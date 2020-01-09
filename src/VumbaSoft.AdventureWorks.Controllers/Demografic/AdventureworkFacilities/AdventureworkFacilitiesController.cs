using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Demografic
{
    [Area("Demografic")]
    public class AdventureworkFacilitiesController : ValidatedController<IAdventureworkFacilityValidator, IAdventureworkFacilityService>
    {
        public AdventureworkFacilitiesController(IAdventureworkFacilityValidator validator, IAdventureworkFacilityService service)
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
        public ActionResult Create(AdventureworkFacilityView facility)
        {
            if (!Validator.CanCreate(facility))
                return View(facility);

            Service.Create(facility);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<AdventureworkFacilityView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<AdventureworkFacilityView>(id));
        }

        [HttpPost]
        public ActionResult Edit(AdventureworkFacilityView facility)
        {
            if (!Validator.CanEdit(facility))
                return View(facility);

            Service.Edit(facility);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<AdventureworkFacilityView>(id));
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
