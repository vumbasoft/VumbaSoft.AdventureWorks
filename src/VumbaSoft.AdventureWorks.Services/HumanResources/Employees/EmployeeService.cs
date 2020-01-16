using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Employee, TView>(id);
        }
        public IQueryable<EmployeeView> GetViews()
        {
            return UnitOfWork
                .Select<Employee>()
                .To<EmployeeView>()
                .OrderByDescending(employee => employee.Id);
        }

        public void Create(EmployeeView view)
        {
            Employee employee = UnitOfWork.To<Employee>(view);

            UnitOfWork.Insert(employee);
            UnitOfWork.Commit();
        }
        public void Edit(EmployeeView view)
        {
            Employee employee = UnitOfWork.To<Employee>(view);

            UnitOfWork.Update(employee);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Employee>(id);
            UnitOfWork.Commit();
        }
    }
}
