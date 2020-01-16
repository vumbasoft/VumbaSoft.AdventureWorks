using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class WorkOrderService : BaseService, IWorkOrderService
    {
        public WorkOrderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<WorkOrder, TView>(id);
        }
        public IQueryable<WorkOrderView> GetViews()
        {
            return UnitOfWork
                .Select<WorkOrder>()
                .To<WorkOrderView>()
                .OrderByDescending(order => order.Id);
        }

        public void Create(WorkOrderView view)
        {
            WorkOrder order = UnitOfWork.To<WorkOrder>(view);

            UnitOfWork.Insert(order);
            UnitOfWork.Commit();
        }
        public void Edit(WorkOrderView view)
        {
            WorkOrder order = UnitOfWork.To<WorkOrder>(view);

            UnitOfWork.Update(order);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<WorkOrder>(id);
            UnitOfWork.Commit();
        }
    }
}
