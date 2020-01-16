using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IEmployeeService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<EmployeeView> GetViews();

        void Create(EmployeeView view);
        void Edit(EmployeeView view);
        void Delete(Int32 id);
    }
}
