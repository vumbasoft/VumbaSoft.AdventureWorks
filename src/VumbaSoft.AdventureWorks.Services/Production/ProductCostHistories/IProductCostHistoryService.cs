using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductCostHistoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductCostHistoryView> GetViews();

        void Create(ProductCostHistoryView view);
        void Edit(ProductCostHistoryView view);
        void Delete(Int32 id);
    }
}
