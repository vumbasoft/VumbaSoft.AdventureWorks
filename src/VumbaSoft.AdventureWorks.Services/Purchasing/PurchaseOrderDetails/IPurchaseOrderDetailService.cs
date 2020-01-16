using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IPurchaseOrderDetailService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<PurchaseOrderDetailView> GetViews();

        void Create(PurchaseOrderDetailView view);
        void Edit(PurchaseOrderDetailView view);
        void Delete(Int32 id);
    }
}
