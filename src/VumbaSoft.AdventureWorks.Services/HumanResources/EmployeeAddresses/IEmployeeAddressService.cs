using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IEmployeeAddressService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<EmployeeAddressView> GetViews();

        void Create(EmployeeAddressView view);
        void Edit(EmployeeAddressView view);
        void Delete(Int32 id);
    }
}
