using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IWorkOrderService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<WorkOrderView> GetViews();

        void Create(WorkOrderView view);
        void Edit(WorkOrderView view);
        void Delete(Int32 id);
    }
}
