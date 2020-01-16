using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesOrderHeaderSalesReasonService : BaseService, ISalesOrderHeaderSalesReasonService
    {
        public SalesOrderHeaderSalesReasonService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesOrderHeaderSalesReason, TView>(id);
        }
        public IQueryable<SalesOrderHeaderSalesReasonView> GetViews()
        {
            return UnitOfWork
                .Select<SalesOrderHeaderSalesReason>()
                .To<SalesOrderHeaderSalesReasonView>()
                .OrderByDescending(reason => reason.Id);
        }

        public void Create(SalesOrderHeaderSalesReasonView view)
        {
            SalesOrderHeaderSalesReason reason = UnitOfWork.To<SalesOrderHeaderSalesReason>(view);

            UnitOfWork.Insert(reason);
            UnitOfWork.Commit();
        }
        public void Edit(SalesOrderHeaderSalesReasonView view)
        {
            SalesOrderHeaderSalesReason reason = UnitOfWork.To<SalesOrderHeaderSalesReason>(view);

            UnitOfWork.Update(reason);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesOrderHeaderSalesReason>(id);
            UnitOfWork.Commit();
        }
    }
}
