using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IPurchaseOrderHeaderService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<PurchaseOrderHeaderView> GetViews();

        void Create(PurchaseOrderHeaderView view);
        void Edit(PurchaseOrderHeaderView view);
        void Delete(Int32 id);
    }
}
