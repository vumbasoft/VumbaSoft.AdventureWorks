using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Sales
{
    [Area("Sales")]
    public class ShoppingCartItemsController : ValidatedController<IShoppingCartItemValidator, IShoppingCartItemService>
    {
        public ShoppingCartItemsController(IShoppingCartItemValidator validator, IShoppingCartItemService service)
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
        public ActionResult Create(ShoppingCartItemView item)
        {
            if (!Validator.CanCreate(item))
                return View(item);

            Service.Create(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ShoppingCartItemView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ShoppingCartItemView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ShoppingCartItemView item)
        {
            if (!Validator.CanEdit(item))
                return View(item);

            Service.Edit(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ShoppingCartItemView>(id));
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
