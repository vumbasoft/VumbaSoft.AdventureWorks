using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IVendorAddressService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<VendorAddressView> GetViews();

        void Create(VendorAddressView view);
        void Edit(VendorAddressView view);
        void Delete(Int32 id);
    }
}
