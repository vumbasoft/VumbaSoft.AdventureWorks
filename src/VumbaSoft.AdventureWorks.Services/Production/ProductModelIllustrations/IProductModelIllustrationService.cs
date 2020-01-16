using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductModelIllustrationService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductModelIllustrationView> GetViews();

        void Create(ProductModelIllustrationView view);
        void Edit(ProductModelIllustrationView view);
        void Delete(Int32 id);
    }
}
