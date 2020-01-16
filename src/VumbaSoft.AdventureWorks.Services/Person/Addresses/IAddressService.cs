using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IAddressService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<AddressView> GetViews();

        void Create(AddressView view);
        void Edit(AddressView view);
        void Delete(Int32 id);
    }
}
