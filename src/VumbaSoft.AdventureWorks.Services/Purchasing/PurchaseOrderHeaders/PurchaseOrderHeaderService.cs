using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class PurchaseOrderHeaderService : BaseService, IPurchaseOrderHeaderService
    {
        public PurchaseOrderHeaderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<PurchaseOrderHeader, TView>(id);
        }
        public IQueryable<PurchaseOrderHeaderView> GetViews()
        {
            return UnitOfWork
                .Select<PurchaseOrderHeader>()
                .To<PurchaseOrderHeaderView>()
                .OrderByDescending(header => header.Id);
        }

        public void Create(PurchaseOrderHeaderView view)
        {
            PurchaseOrderHeader header = UnitOfWork.To<PurchaseOrderHeader>(view);

            UnitOfWork.Insert(header);
            UnitOfWork.Commit();
        }
        public void Edit(PurchaseOrderHeaderView view)
        {
            PurchaseOrderHeader header = UnitOfWork.To<PurchaseOrderHeader>(view);

            UnitOfWork.Update(header);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<PurchaseOrderHeader>(id);
            UnitOfWork.Commit();
        }
    }
}
