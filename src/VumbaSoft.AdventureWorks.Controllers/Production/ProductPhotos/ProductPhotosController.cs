using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class ProductPhotosController : ValidatedController<IProductPhotoValidator, IProductPhotoService>
    {
        public ProductPhotosController(IProductPhotoValidator validator, IProductPhotoService service)
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
        public ActionResult Create(ProductPhotoView photo)
        {
            if (!Validator.CanCreate(photo))
                return View(photo);

            Service.Create(photo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductPhotoView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductPhotoView>(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductPhotoView photo)
        {
            if (!Validator.CanEdit(photo))
                return View(photo);

            Service.Edit(photo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<ProductPhotoView>(id));
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
