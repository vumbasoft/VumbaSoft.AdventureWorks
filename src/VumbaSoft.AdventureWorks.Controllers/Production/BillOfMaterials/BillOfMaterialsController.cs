using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class BillOfMaterialsController : ValidatedController<IBillOfMaterialValidator, IBillOfMaterialService>
    {
        public BillOfMaterialsController(IBillOfMaterialValidator validator, IBillOfMaterialService service)
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
        public ActionResult Create(BillOfMaterialView material)
        {
            if (!Validator.CanCreate(material))
                return View(material);

            Service.Create(material);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<BillOfMaterialView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<BillOfMaterialView>(id));
        }

        [HttpPost]
        public ActionResult Edit(BillOfMaterialView material)
        {
            if (!Validator.CanEdit(material))
                return View(material);

            Service.Edit(material);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<BillOfMaterialView>(id));
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
