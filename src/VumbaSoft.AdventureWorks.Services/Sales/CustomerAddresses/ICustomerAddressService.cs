using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICustomerAddressService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CustomerAddressView> GetViews();

        void Create(CustomerAddressView view);
        void Edit(CustomerAddressView view);
        void Delete(Int32 id);
    }
}
