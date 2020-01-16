using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IVendorService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<VendorView> GetViews();

        void Create(VendorView view);
        void Edit(VendorView view);
        void Delete(Int32 id);
    }
}
