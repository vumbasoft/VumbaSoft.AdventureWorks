using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesOrderHeaderService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesOrderHeaderView> GetViews();

        void Create(SalesOrderHeaderView view);
        void Edit(SalesOrderHeaderView view);
        void Delete(Int32 id);
    }
}
