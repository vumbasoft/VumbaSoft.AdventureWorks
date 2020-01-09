using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ITenantService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<TenantView> GetViews();

        void Create(TenantView view);
        void Edit(TenantView view);
        void Delete(Int32 id);
    }
}
