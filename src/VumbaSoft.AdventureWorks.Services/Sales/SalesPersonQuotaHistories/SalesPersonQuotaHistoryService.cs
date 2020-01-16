using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesPersonQuotaHistoryService : BaseService, ISalesPersonQuotaHistoryService
    {
        public SalesPersonQuotaHistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesPersonQuotaHistory, TView>(id);
        }
        public IQueryable<SalesPersonQuotaHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<SalesPersonQuotaHistory>()
                .To<SalesPersonQuotaHistoryView>()
                .OrderByDescending(history => history.Id);
        }

        public void Create(SalesPersonQuotaHistoryView view)
        {
            SalesPersonQuotaHistory history = UnitOfWork.To<SalesPersonQuotaHistory>(view);

            UnitOfWork.Insert(history);
            UnitOfWork.Commit();
        }
        public void Edit(SalesPersonQuotaHistoryView view)
        {
            SalesPersonQuotaHistory history = UnitOfWork.To<SalesPersonQuotaHistory>(view);

            UnitOfWork.Update(history);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesPersonQuotaHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
