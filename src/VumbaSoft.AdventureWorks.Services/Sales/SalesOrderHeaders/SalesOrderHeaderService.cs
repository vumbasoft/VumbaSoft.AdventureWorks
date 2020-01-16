using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesOrderHeaderService : BaseService, ISalesOrderHeaderService
    {
        public SalesOrderHeaderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesOrderHeader, TView>(id);
        }
        public IQueryable<SalesOrderHeaderView> GetViews()
        {
            return UnitOfWork
                .Select<SalesOrderHeader>()
                .To<SalesOrderHeaderView>()
                .OrderByDescending(header => header.Id);
        }

        public void Create(SalesOrderHeaderView view)
        {
            SalesOrderHeader header = UnitOfWork.To<SalesOrderHeader>(view);

            UnitOfWork.Insert(header);
            UnitOfWork.Commit();
        }
        public void Edit(SalesOrderHeaderView view)
        {
            SalesOrderHeader header = UnitOfWork.To<SalesOrderHeader>(view);

            UnitOfWork.Update(header);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesOrderHeader>(id);
            UnitOfWork.Commit();
        }
    }
}
