using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class EmployeepayhistoryService : BaseService, IEmployeepayhistoryService
    {
        public EmployeepayhistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<EmployeePayHistory, TView>(id);
        }
        public IQueryable<EmployeePayHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<EmployeePayHistory>()
                .To<EmployeePayHistoryView>()
                .OrderByDescending(employeepayhistory => employeepayhistory.Id);
        }

        public void Create(EmployeePayHistoryView view)
        {
            EmployeePayHistory employeepayhistory = UnitOfWork.To<EmployeePayHistory>(view);

            UnitOfWork.Insert(employeepayhistory);
            UnitOfWork.Commit();
        }
        public void Edit(EmployeePayHistoryView view)
        {
            EmployeePayHistory employeepayhistory = UnitOfWork.To<EmployeePayHistory>(view);

            UnitOfWork.Update(employeepayhistory);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<EmployeePayHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
