using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductProductPhotoService : BaseService, IProductProductPhotoService
    {
        public ProductProductPhotoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductProductPhoto, TView>(id);
        }
        public IQueryable<ProductProductPhotoView> GetViews()
        {
            return UnitOfWork
                .Select<ProductProductPhoto>()
                .To<ProductProductPhotoView>()
                .OrderByDescending(photo => photo.Id);
        }

        public void Create(ProductProductPhotoView view)
        {
            ProductProductPhoto photo = UnitOfWork.To<ProductProductPhoto>(view);

            UnitOfWork.Insert(photo);
            UnitOfWork.Commit();
        }
        public void Edit(ProductProductPhotoView view)
        {
            ProductProductPhoto photo = UnitOfWork.To<ProductProductPhoto>(view);

            UnitOfWork.Update(photo);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductProductPhoto>(id);
            UnitOfWork.Commit();
        }
    }
}
