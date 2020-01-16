using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IEmployeedepartmenthistoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<EmployeeDepartmentHistoryView> GetViews();

        void Create(EmployeeDepartmentHistoryView view);
        void Edit(EmployeeDepartmentHistoryView view);
        void Delete(Int32 id);
    }
}
