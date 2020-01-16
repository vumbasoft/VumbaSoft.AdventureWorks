using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IStoreService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StoreView> GetViews();

        void Create(StoreView view);
        void Edit(StoreView view);
        void Delete(Int32 id);
    }
}
