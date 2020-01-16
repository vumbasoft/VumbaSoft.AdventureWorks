using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Product, TView>(id);
        }
        public IQueryable<ProductView> GetViews()
        {
            return UnitOfWork
                .Select<Product>()
                .To<ProductView>()
                .OrderByDescending(product => product.Id);
        }

        public void Create(ProductView view)
        {
            Product product = UnitOfWork.To<Product>(view);

            UnitOfWork.Insert(product);
            UnitOfWork.Commit();
        }
        public void Edit(ProductView view)
        {
            Product product = UnitOfWork.To<Product>(view);

            UnitOfWork.Update(product);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Product>(id);
            UnitOfWork.Commit();
        }
    }
}
