using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class EmployeedepartmenthistoryService : BaseService, IEmployeedepartmenthistoryService
    {
        public EmployeedepartmenthistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<EmployeeDepartmentHistory, TView>(id);
        }
        public IQueryable<EmployeeDepartmentHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<EmployeeDepartmentHistory>()
                .To<EmployeeDepartmentHistoryView>()
                .OrderByDescending(employeedepartmenthistory => employeedepartmenthistory.Id);
        }

        public void Create(EmployeeDepartmentHistoryView view)
        {
            EmployeeDepartmentHistory employeedepartmenthistory = UnitOfWork.To<EmployeeDepartmentHistory>(view);

            UnitOfWork.Insert(employeedepartmenthistory);
            UnitOfWork.Commit();
        }
        public void Edit(EmployeeDepartmentHistoryView view)
        {
            EmployeeDepartmentHistory employeedepartmenthistory = UnitOfWork.To<EmployeeDepartmentHistory>(view);

            UnitOfWork.Update(employeedepartmenthistory);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<EmployeeDepartmentHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
