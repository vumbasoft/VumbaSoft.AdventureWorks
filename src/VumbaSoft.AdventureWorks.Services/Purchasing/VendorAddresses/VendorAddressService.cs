using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class VendorAddressService : BaseService, IVendorAddressService
    {
        public VendorAddressService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<VendorAddress, TView>(id);
        }
        public IQueryable<VendorAddressView> GetViews()
        {
            return UnitOfWork
                .Select<VendorAddress>()
                .To<VendorAddressView>()
                .OrderByDescending(address => address.Id);
        }

        public void Create(VendorAddressView view)
        {
            VendorAddress address = UnitOfWork.To<VendorAddress>(view);

            UnitOfWork.Insert(address);
            UnitOfWork.Commit();
        }
        public void Edit(VendorAddressView view)
        {
            VendorAddress address = UnitOfWork.To<VendorAddress>(view);

            UnitOfWork.Update(address);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<VendorAddress>(id);
            UnitOfWork.Commit();
        }
    }
}
