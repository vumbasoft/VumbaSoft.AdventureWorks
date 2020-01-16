using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICustomerService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CustomerView> GetViews();

        void Create(CustomerView view);
        void Edit(CustomerView view);
        void Delete(Int32 id);
    }
}
