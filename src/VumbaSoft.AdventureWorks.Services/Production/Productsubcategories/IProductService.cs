using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductView> GetViews();

        void Create(ProductView view);
        void Edit(ProductView view);
        void Delete(Int32 id);
    }
}
