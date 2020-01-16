using Microsoft.AspNetCore.Mvc;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Services;
using VumbaSoft.AdventureWorks.Validators;
using System;

namespace VumbaSoft.AdventureWorks.Controllers.Production
{
    [Area("Production")]
    public class TransactionHistoriesController : ValidatedController<ITransactionHistoryValidator, ITransactionHistoryService>
    {
        public TransactionHistoriesController(ITransactionHistoryValidator validator, ITransactionHistoryService service)
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
        public ActionResult Create(TransactionHistoryView history)
        {
            if (!Validator.CanCreate(history))
                return View(history);

            Service.Create(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryView>(id));
        }

        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryView>(id));
        }

        [HttpPost]
        public ActionResult Edit(TransactionHistoryView history)
        {
            if (!Validator.CanEdit(history))
                return View(history);

            Service.Edit(history);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Int32 id)
        {
            return NotEmptyView(Service.Get<TransactionHistoryView>(id));
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
