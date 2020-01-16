using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class VendorService : BaseService, IVendorService
    {
        public VendorService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Vendor, TView>(id);
        }
        public IQueryable<VendorView> GetViews()
        {
            return UnitOfWork
                .Select<Vendor>()
                .To<VendorView>()
                .OrderByDescending(vendor => vendor.Id);
        }

        public void Create(VendorView view)
        {
            Vendor vendor = UnitOfWork.To<Vendor>(view);

            UnitOfWork.Insert(vendor);
            UnitOfWork.Commit();
        }
        public void Edit(VendorView view)
        {
            Vendor vendor = UnitOfWork.To<Vendor>(view);

            UnitOfWork.Update(vendor);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Vendor>(id);
            UnitOfWork.Commit();
        }
    }
}
