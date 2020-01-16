using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IProductPhotoService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ProductPhotoView> GetViews();

        void Create(ProductPhotoView view);
        void Edit(ProductPhotoView view);
        void Delete(Int32 id);
    }
}
