using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Customer, TView>(id);
        }
        public IQueryable<CustomerView> GetViews()
        {
            return UnitOfWork
                .Select<Customer>()
                .To<CustomerView>()
                .OrderByDescending(customer => customer.Id);
        }

        public void Create(CustomerView view)
        {
            Customer customer = UnitOfWork.To<Customer>(view);

            UnitOfWork.Insert(customer);
            UnitOfWork.Commit();
        }
        public void Edit(CustomerView view)
        {
            Customer customer = UnitOfWork.To<Customer>(view);

            UnitOfWork.Update(customer);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Customer>(id);
            UnitOfWork.Commit();
        }
    }
}
