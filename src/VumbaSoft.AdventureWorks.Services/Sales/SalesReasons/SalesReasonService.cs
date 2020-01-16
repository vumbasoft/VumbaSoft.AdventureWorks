using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesReasonService : BaseService, ISalesReasonService
    {
        public SalesReasonService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesReason, TView>(id);
        }
        public IQueryable<SalesReasonView> GetViews()
        {
            return UnitOfWork
                .Select<SalesReason>()
                .To<SalesReasonView>()
                .OrderByDescending(reason => reason.Id);
        }

        public void Create(SalesReasonView view)
        {
            SalesReason reason = UnitOfWork.To<SalesReason>(view);

            UnitOfWork.Insert(reason);
            UnitOfWork.Commit();
        }
        public void Edit(SalesReasonView view)
        {
            SalesReason reason = UnitOfWork.To<SalesReason>(view);

            UnitOfWork.Update(reason);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesReason>(id);
            UnitOfWork.Commit();
        }
    }
}
