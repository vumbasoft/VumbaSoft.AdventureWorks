using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IVendorContactService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<VendorContactView> GetViews();

        void Create(VendorContactView view);
        void Edit(VendorContactView view);
        void Delete(Int32 id);
    }
}
