using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Department, TView>(id);
        }
        public IQueryable<DepartmentView> GetViews()
        {
            return UnitOfWork
                .Select<Department>()
                .To<DepartmentView>()
                .OrderByDescending(department => department.Id);
        }

        public void Create(DepartmentView view)
        {
            Department department = UnitOfWork.To<Department>(view);

            UnitOfWork.Insert(department);
            UnitOfWork.Commit();
        }
        public void Edit(DepartmentView view)
        {
            Department department = UnitOfWork.To<Department>(view);

            UnitOfWork.Update(department);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Department>(id);
            UnitOfWork.Commit();
        }
    }
}
