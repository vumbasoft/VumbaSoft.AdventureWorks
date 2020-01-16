using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductProductPhotoService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductProductPhotoView> GetViews();

        void Create(ProductProductPhotoView view);
        void Edit(ProductProductPhotoView view);
        void Delete(Int32 id);
    }
}
