using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductPhotoService : BaseService, IProductPhotoService
    {
        public ProductPhotoService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductPhoto, TView>(id);
        }
        public IQueryable<ProductPhotoView> GetViews()
        {
            return UnitOfWork
                .Select<ProductPhoto>()
                .To<ProductPhotoView>()
                .OrderByDescending(photo => photo.Id);
        }

        public void Create(ProductPhotoView view)
        {
            ProductPhoto photo = UnitOfWork.To<ProductPhoto>(view);

            UnitOfWork.Insert(photo);
            UnitOfWork.Commit();
        }
        public void Edit(ProductPhotoView view)
        {
            ProductPhoto photo = UnitOfWork.To<ProductPhoto>(view);

            UnitOfWork.Update(photo);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductPhoto>(id);
            UnitOfWork.Commit();
        }
    }
}
