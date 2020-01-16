using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Person
{
    [Area("Person")]
    public class StateProvincesController : ValidatedController<IStateProvinceValidator, IStateProvinceService>
    {
        public StateProvincesController(IStateProvinceValidator validator, IStateProvinceService service)
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
        public ActionResult Create(StateProvinceView province)
        {
            if (!Validator.CanCreate(province))
                return View(province);

            Service.Create(province);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<StateProvinceView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<StateProvinceView>(id));
        }

        [HttpPost]
        public ActionResult Edit(StateProvinceView province)
        {
            if (!Validator.CanEdit(province))
                return View(province);

            Service.Edit(province);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<StateProvinceView>(id));
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
