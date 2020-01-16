using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IWorkOrderRoutingService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<WorkOrderRoutingView> GetViews();

        void Create(WorkOrderRoutingView view);
        void Edit(WorkOrderRoutingView view);
        void Delete(Int32 id);
    }
}
