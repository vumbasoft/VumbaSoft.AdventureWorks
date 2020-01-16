using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesTerritoryHistoryService : BaseService, ISalesTerritoryHistoryService
    {
        public SalesTerritoryHistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesTerritoryHistory, TView>(id);
        }
        public IQueryable<SalesTerritoryHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<SalesTerritoryHistory>()
                .To<SalesTerritoryHistoryView>()
                .OrderByDescending(history => history.Id);
        }

        public void Create(SalesTerritoryHistoryView view)
        {
            SalesTerritoryHistory history = UnitOfWork.To<SalesTerritoryHistory>(view);

            UnitOfWork.Insert(history);
            UnitOfWork.Commit();
        }
        public void Edit(SalesTerritoryHistoryView view)
        {
            SalesTerritoryHistory history = UnitOfWork.To<SalesTerritoryHistory>(view);

            UnitOfWork.Update(history);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesTerritoryHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
