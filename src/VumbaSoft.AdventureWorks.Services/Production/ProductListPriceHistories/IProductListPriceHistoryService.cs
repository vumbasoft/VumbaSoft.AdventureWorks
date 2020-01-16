using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductListPriceHistoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductListPriceHistoryView> GetViews();

        void Create(ProductListPriceHistoryView view);
        void Edit(ProductListPriceHistoryView view);
        void Delete(Int32 id);
    }
}
