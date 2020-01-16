using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductDescriptionService : BaseService, IProductDescriptionService
    {
        public ProductDescriptionService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductDescription, TView>(id);
        }
        public IQueryable<ProductDescriptionView> GetViews()
        {
            return UnitOfWork
                .Select<ProductDescription>()
                .To<ProductDescriptionView>()
                .OrderByDescending(description => description.Id);
        }

        public void Create(ProductDescriptionView view)
        {
            ProductDescription description = UnitOfWork.To<ProductDescription>(view);

            UnitOfWork.Insert(description);
            UnitOfWork.Commit();
        }
        public void Edit(ProductDescriptionView view)
        {
            ProductDescription description = UnitOfWork.To<ProductDescription>(view);

            UnitOfWork.Update(description);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductDescription>(id);
            UnitOfWork.Commit();
        }
    }
}
