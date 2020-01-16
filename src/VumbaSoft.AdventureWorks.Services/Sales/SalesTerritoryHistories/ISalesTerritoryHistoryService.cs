using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesTerritoryHistoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesTerritoryHistoryView> GetViews();

        void Create(SalesTerritoryHistoryView view);
        void Edit(SalesTerritoryHistoryView view);
        void Delete(Int32 id);
    }
}
