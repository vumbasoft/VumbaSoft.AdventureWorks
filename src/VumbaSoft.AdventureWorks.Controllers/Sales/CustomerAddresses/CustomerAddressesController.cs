using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class CustomerAddressesController : ValidatedController<ICustomerAddressValidator, ICustomerAddressService>
    {
        public CustomerAddressesController(ICustomerAddressValidator validator, ICustomerAddressService service)
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
        public ActionResult Create(CustomerAddressView address)
        {
            if (!Validator.CanCreate(address))
                return View(address);

            Service.Create(address);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomerAddressView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomerAddressView>(id));
        }

        [HttpPost]
        public ActionResult Edit(CustomerAddressView address)
        {
            if (!Validator.CanEdit(address))
                return View(address);

            Service.Edit(address);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<CustomerAddressView>(id));
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
