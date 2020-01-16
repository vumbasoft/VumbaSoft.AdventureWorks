using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductDescriptionService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductDescriptionView> GetViews();

        void Create(ProductDescriptionView view);
        void Edit(ProductDescriptionView view);
        void Delete(Int32 id);
    }
}
