using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesOrderDetailService : BaseService, ISalesOrderDetailService
    {
        public SalesOrderDetailService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesOrderDetail, TView>(id);
        }
        public IQueryable<SalesOrderDetailView> GetViews()
        {
            return UnitOfWork
                .Select<SalesOrderDetail>()
                .To<SalesOrderDetailView>()
                .OrderByDescending(detail => detail.Id);
        }

        public void Create(SalesOrderDetailView view)
        {
            SalesOrderDetail detail = UnitOfWork.To<SalesOrderDetail>(view);

            UnitOfWork.Insert(detail);
            UnitOfWork.Commit();
        }
        public void Edit(SalesOrderDetailView view)
        {
            SalesOrderDetail detail = UnitOfWork.To<SalesOrderDetail>(view);

            UnitOfWork.Update(detail);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesOrderDetail>(id);
            UnitOfWork.Commit();
        }
    }
}
