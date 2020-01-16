using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Person
{
    [Area("Person")]
    public class AddressTypesController : ValidatedController<IAddresstypeValidator, IAddresstypeService>
    {
        public AddressTypesController(IAddresstypeValidator validator, IAddresstypeService service)
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
        public ActionResult Create(AddresstypeView addresstype)
        {
            if (!Validator.CanCreate(addresstype))
                return View(addresstype);

            Service.Create(addresstype);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<AddresstypeView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<AddresstypeView>(id));
        }

        [HttpPost]
        public ActionResult Edit(AddresstypeView addresstype)
        {
            if (!Validator.CanEdit(addresstype))
                return View(addresstype);

            Service.Edit(addresstype);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<AddresstypeView>(id));
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
