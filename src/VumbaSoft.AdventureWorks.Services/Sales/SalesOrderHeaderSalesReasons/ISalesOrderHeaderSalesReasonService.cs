using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesOrderHeaderSalesReasonService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesOrderHeaderSalesReasonView> GetViews();

        void Create(SalesOrderHeaderSalesReasonView view);
        void Edit(SalesOrderHeaderSalesReasonView view);
        void Delete(Int32 id);
    }
}
