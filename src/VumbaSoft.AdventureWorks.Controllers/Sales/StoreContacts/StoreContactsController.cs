using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class StoreContactsController : ValidatedController<IStoreContactValidator, IStoreContactService>
    {
        public StoreContactsController(IStoreContactValidator validator, IStoreContactService service)
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
        public ActionResult Create(StoreContactView contact)
        {
            if (!Validator.CanCreate(contact))
                return View(contact);

            Service.Create(contact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreContactView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreContactView>(id));
        }

        [HttpPost]
        public ActionResult Edit(StoreContactView contact)
        {
            if (!Validator.CanEdit(contact))
                return View(contact);

            Service.Edit(contact);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<StoreContactView>(id));
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