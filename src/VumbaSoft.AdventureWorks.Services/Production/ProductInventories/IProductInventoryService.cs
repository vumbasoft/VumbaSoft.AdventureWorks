using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductInventoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductInventoryView> GetViews();

        void Create(ProductInventoryView view);
        void Edit(ProductInventoryView view);
        void Delete(Int32 id);
    }
}
