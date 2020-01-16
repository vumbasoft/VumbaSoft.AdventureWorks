using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesOrderDetailService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesOrderDetailView> GetViews();

        void Create(SalesOrderDetailView view);
        void Edit(SalesOrderDetailView view);
        void Delete(Int32 id);
    }
}
