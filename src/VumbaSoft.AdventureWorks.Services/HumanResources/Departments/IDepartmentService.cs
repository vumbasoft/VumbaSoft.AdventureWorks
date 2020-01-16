using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IDepartmentService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<DepartmentView> GetViews();

        void Create(DepartmentView view);
        void Edit(DepartmentView view);
        void Delete(Int32 id);
    }
}
