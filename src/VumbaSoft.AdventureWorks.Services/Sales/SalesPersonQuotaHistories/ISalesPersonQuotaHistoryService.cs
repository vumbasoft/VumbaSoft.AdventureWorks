using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesPersonQuotaHistoryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesPersonQuotaHistoryView> GetViews();

        void Create(SalesPersonQuotaHistoryView view);
        void Edit(SalesPersonQuotaHistoryView view);
        void Delete(Int32 id);
    }
}
