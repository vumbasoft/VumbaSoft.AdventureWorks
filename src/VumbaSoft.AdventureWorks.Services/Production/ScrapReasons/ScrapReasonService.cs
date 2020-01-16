using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ScrapReasonService : BaseService, IScrapReasonService
    {
        public ScrapReasonService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ScrapReason, TView>(id);
        }
        public IQueryable<ScrapReasonView> GetViews()
        {
            return UnitOfWork
                .Select<ScrapReason>()
                .To<ScrapReasonView>()
                .OrderByDescending(reason => reason.Id);
        }

        public void Create(ScrapReasonView view)
        {
            ScrapReason reason = UnitOfWork.To<ScrapReason>(view);

            UnitOfWork.Insert(reason);
            UnitOfWork.Commit();
        }
        public void Edit(ScrapReasonView view)
        {
            ScrapReason reason = UnitOfWork.To<ScrapReason>(view);

            UnitOfWork.Update(reason);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ScrapReason>(id);
            UnitOfWork.Commit();
        }
    }
}
