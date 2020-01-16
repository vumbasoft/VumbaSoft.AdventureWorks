using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductCategoryService : BaseService, IProductCategoryService
    {
        public ProductCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductCategory, TView>(id);
        }
        public IQueryable<ProductCategoryView> GetViews()
        {
            return UnitOfWork
                .Select<ProductCategory>()
                .To<ProductCategoryView>()
                .OrderByDescending(category => category.Id);
        }

        public void Create(ProductCategoryView view)
        {
            ProductCategory category = UnitOfWork.To<ProductCategory>(view);

            UnitOfWork.Insert(category);
            UnitOfWork.Commit();
        }
        public void Edit(ProductCategoryView view)
        {
            ProductCategory category = UnitOfWork.To<ProductCategory>(view);

            UnitOfWork.Update(category);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductCategory>(id);
            UnitOfWork.Commit();
        }
    }
}
