using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class StoresController : ValidatedController<IStoreValidator, IStoreService>
    {
        public StoresController(IStoreValidator validator, IStoreService service)
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
        public ActionResult Create(StoreView store)
        {
            if (!Validator.CanCreate(store))
                return View(store);

            Service.Create(store);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreView>(id));
        }

        [HttpPost]
        public ActionResult Edit(StoreView store)
        {
            if (!Validator.CanEdit(store))
                return View(store);

            Service.Edit(store);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreView>(id));
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
