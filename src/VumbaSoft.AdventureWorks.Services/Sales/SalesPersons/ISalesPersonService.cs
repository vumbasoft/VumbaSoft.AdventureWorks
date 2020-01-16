using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesPersonService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesPersonView> GetViews();

        void Create(SalesPersonView view);
        void Edit(SalesPersonView view);
        void Delete(Int32 id);
    }
}
