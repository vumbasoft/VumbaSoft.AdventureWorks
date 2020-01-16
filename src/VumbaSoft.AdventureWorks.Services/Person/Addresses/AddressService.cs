using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class AddressService : BaseService, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Address, TView>(id);
        }
        public IQueryable<AddressView> GetViews()
        {
            return UnitOfWork
                .Select<Address>()
                .To<AddressView>()
                .OrderByDescending(address => address.Id);
        }

        public void Create(AddressView view)
        {
            Address address = UnitOfWork.To<Address>(view);

            UnitOfWork.Insert(address);
            UnitOfWork.Commit();
        }
        public void Edit(AddressView view)
        {
            Address address = UnitOfWork.To<Address>(view);

            UnitOfWork.Update(address);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Address>(id);
            UnitOfWork.Commit();
        }
    }
}
