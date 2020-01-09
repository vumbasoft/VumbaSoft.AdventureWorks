using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.LookupSettings
{
    [Area("LookupSettings")]
    public class CustomCareTypesController : ValidatedController<ICustomCareTypeValidator, ICustomCareTypeService>
    {
        public CustomCareTypesController(ICustomCareTypeValidator validator, ICustomCareTypeService service)
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
        public ActionResult Create(CustomCareTypeView type)
        {
            if (!Validator.CanCreate(type))
                return View(type);

            Service.Create(type);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomCareTypeView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomCareTypeView>(id));
        }

        [HttpPost]
        public ActionResult Edit(CustomCareTypeView type)
        {
            if (!Validator.CanEdit(type))
                return View(type);

            Service.Edit(type);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomCareTypeView>(id));
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
