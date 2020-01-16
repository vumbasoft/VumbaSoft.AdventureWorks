using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class UnitMeasuresController : ValidatedController<IUnitMeasureValidator, IUnitMeasureService>
    {
        public UnitMeasuresController(IUnitMeasureValidator validator, IUnitMeasureService service)
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
        public ActionResult Create(UnitMeasureView measure)
        {
            if (!Validator.CanCreate(measure))
                return View(measure);

            Service.Create(measure);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<UnitMeasureView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<UnitMeasureView>(id));
        }

        [HttpPost]
        public ActionResult Edit(UnitMeasureView measure)
        {
            if (!Validator.CanEdit(measure))
                return View(measure);

            Service.Edit(measure);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<UnitMeasureView>(id));
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
