using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesTerritoryService : BaseService, ISalesTerritoryService
    {
        public SalesTerritoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesTerritory, TView>(id);
        }
        public IQueryable<SalesTerritoryView> GetViews()
        {
            return UnitOfWork
                .Select<SalesTerritory>()
                .To<SalesTerritoryView>()
                .OrderByDescending(territory => territory.Id);
        }

        public void Create(SalesTerritoryView view)
        {
            SalesTerritory territory = UnitOfWork.To<SalesTerritory>(view);

            UnitOfWork.Insert(territory);
            UnitOfWork.Commit();
        }
        public void Edit(SalesTerritoryView view)
        {
            SalesTerritory territory = UnitOfWork.To<SalesTerritory>(view);

            UnitOfWork.Update(territory);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesTerritory>(id);
            UnitOfWork.Commit();
        }
    }
}
