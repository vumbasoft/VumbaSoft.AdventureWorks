using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductCategoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductCategoryView> GetViews();

        void Create(ProductCategoryView view);
        void Edit(ProductCategoryView view);
        void Delete(Int32 id);
    }
}
