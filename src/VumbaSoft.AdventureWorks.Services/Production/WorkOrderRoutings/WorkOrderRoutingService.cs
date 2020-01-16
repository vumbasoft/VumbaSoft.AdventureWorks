using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class WorkOrderRoutingService : BaseService, IWorkOrderRoutingService
    {
        public WorkOrderRoutingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<WorkOrderRouting, TView>(id);
        }
        public IQueryable<WorkOrderRoutingView> GetViews()
        {
            return UnitOfWork
                .Select<WorkOrderRouting>()
                .To<WorkOrderRoutingView>()
                .OrderByDescending(routing => routing.Id);
        }

        public void Create(WorkOrderRoutingView view)
        {
            WorkOrderRouting routing = UnitOfWork.To<WorkOrderRouting>(view);

            UnitOfWork.Insert(routing);
            UnitOfWork.Commit();
        }
        public void Edit(WorkOrderRoutingView view)
        {
            WorkOrderRouting routing = UnitOfWork.To<WorkOrderRouting>(view);

            UnitOfWork.Update(routing);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<WorkOrderRouting>(id);
            UnitOfWork.Commit();
        }
    }
}
