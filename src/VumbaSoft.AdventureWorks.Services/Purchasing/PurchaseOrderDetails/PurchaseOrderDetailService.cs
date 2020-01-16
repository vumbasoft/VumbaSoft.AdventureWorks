using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class PurchaseOrderDetailService : BaseService, IPurchaseOrderDetailService
    {
        public PurchaseOrderDetailService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<PurchaseOrderDetail, TView>(id);
        }
        public IQueryable<PurchaseOrderDetailView> GetViews()
        {
            return UnitOfWork
                .Select<PurchaseOrderDetail>()
                .To<PurchaseOrderDetailView>()
                .OrderByDescending(detail => detail.Id);
        }

        public void Create(PurchaseOrderDetailView view)
        {
            PurchaseOrderDetail detail = UnitOfWork.To<PurchaseOrderDetail>(view);

            UnitOfWork.Insert(detail);
            UnitOfWork.Commit();
        }
        public void Edit(PurchaseOrderDetailView view)
        {
            PurchaseOrderDetail detail = UnitOfWork.To<PurchaseOrderDetail>(view);

            UnitOfWork.Update(detail);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<PurchaseOrderDetail>(id);
            UnitOfWork.Commit();
        }
    }
}
