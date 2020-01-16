using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CustomerAddressService : BaseService, ICustomerAddressService
    {
        public CustomerAddressService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CustomerAddress, TView>(id);
        }
        public IQueryable<CustomerAddressView> GetViews()
        {
            return UnitOfWork
                .Select<CustomerAddress>()
                .To<CustomerAddressView>()
                .OrderByDescending(address => address.Id);
        }

        public void Create(CustomerAddressView view)
        {
            CustomerAddress address = UnitOfWork.To<CustomerAddress>(view);

            UnitOfWork.Insert(address);
            UnitOfWork.Commit();
        }
        public void Edit(CustomerAddressView view)
        {
            CustomerAddress address = UnitOfWork.To<CustomerAddress>(view);

            UnitOfWork.Update(address);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CustomerAddress>(id);
            UnitOfWork.Commit();
        }
    }
}
