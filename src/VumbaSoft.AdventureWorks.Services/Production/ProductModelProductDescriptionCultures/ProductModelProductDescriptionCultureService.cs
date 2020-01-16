using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductModelProductDescriptionCultureService : BaseService, IProductModelProductDescriptionCultureService
    {
        public ProductModelProductDescriptionCultureService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductModelProductDescriptionCulture, TView>(id);
        }
        public IQueryable<ProductModelProductDescriptionCultureView> GetViews()
        {
            return UnitOfWork
                .Select<ProductModelProductDescriptionCulture>()
                .To<ProductModelProductDescriptionCultureView>()
                .OrderByDescending(culture => culture.Id);
        }

        public void Create(ProductModelProductDescriptionCultureView view)
        {
            ProductModelProductDescriptionCulture culture = UnitOfWork.To<ProductModelProductDescriptionCulture>(view);

            UnitOfWork.Insert(culture);
            UnitOfWork.Commit();
        }
        public void Edit(ProductModelProductDescriptionCultureView view)
        {
            ProductModelProductDescriptionCulture culture = UnitOfWork.To<ProductModelProductDescriptionCulture>(view);

            UnitOfWork.Update(culture);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductModelProductDescriptionCulture>(id);
            UnitOfWork.Commit();
        }
    }
}
