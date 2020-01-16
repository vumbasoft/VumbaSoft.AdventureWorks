using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesTerritoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesTerritoryView> GetViews();

        void Create(SalesTerritoryView view);
        void Edit(SalesTerritoryView view);
        void Delete(Int32 id);
    }
}
