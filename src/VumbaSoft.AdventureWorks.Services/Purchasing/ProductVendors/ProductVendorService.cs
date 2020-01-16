using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductVendorService : BaseService, IProductVendorService
    {
        public ProductVendorService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductVendor, TView>(id);
        }
        public IQueryable<ProductVendorView> GetViews()
        {
            return UnitOfWork
                .Select<ProductVendor>()
                .To<ProductVendorView>()
                .OrderByDescending(vendor => vendor.Id);
        }

        public void Create(ProductVendorView view)
        {
            ProductVendor vendor = UnitOfWork.To<ProductVendor>(view);

            UnitOfWork.Insert(vendor);
            UnitOfWork.Commit();
        }
        public void Edit(ProductVendorView view)
        {
            ProductVendor vendor = UnitOfWork.To<ProductVendor>(view);

            UnitOfWork.Update(vendor);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductVendor>(id);
            UnitOfWork.Commit();
        }
    }
}
