using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductVendorService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductVendorView> GetViews();

        void Create(ProductVendorView view);
        void Edit(ProductVendorView view);
        void Delete(Int32 id);
    }
}
