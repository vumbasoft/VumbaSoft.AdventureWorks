using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class EmployeeAddressService : BaseService, IEmployeeAddressService
    {
        public EmployeeAddressService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<EmployeeAddress, TView>(id);
        }
        public IQueryable<EmployeeAddressView> GetViews()
        {
            return UnitOfWork
                .Select<EmployeeAddress>()
                .To<EmployeeAddressView>()
                .OrderByDescending(address => address.Id);
        }

        public void Create(EmployeeAddressView view)
        {
            EmployeeAddress address = UnitOfWork.To<EmployeeAddress>(view);

            UnitOfWork.Insert(address);
            UnitOfWork.Commit();
        }
        public void Edit(EmployeeAddressView view)
        {
            EmployeeAddress address = UnitOfWork.To<EmployeeAddress>(view);

            UnitOfWork.Update(address);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<EmployeeAddress>(id);
            UnitOfWork.Commit();
        }
    }
}
