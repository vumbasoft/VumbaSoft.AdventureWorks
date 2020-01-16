using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductSubcategoryService : BaseService, IProductSubcategoryService
    {
        public ProductSubcategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductSubcategory, TView>(id);
        }
        public IQueryable<ProductSubcategoryView> GetViews()
        {
            return UnitOfWork
                .Select<ProductSubcategory>()
                .To<ProductSubcategoryView>()
                .OrderByDescending(subcategory => subcategory.Id);
        }

        public void Create(ProductSubcategoryView view)
        {
            ProductSubcategory subcategory = UnitOfWork.To<ProductSubcategory>(view);

            UnitOfWork.Insert(subcategory);
            UnitOfWork.Commit();
        }
        public void Edit(ProductSubcategoryView view)
        {
            ProductSubcategory subcategory = UnitOfWork.To<ProductSubcategory>(view);

            UnitOfWork.Update(subcategory);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductSubcategory>(id);
            UnitOfWork.Commit();
        }
    }
}
