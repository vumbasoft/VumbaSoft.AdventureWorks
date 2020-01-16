using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IStoreContactService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<StoreContactView> GetViews();

        void Create(StoreContactView view);
        void Edit(StoreContactView view);
        void Delete(Int32 id);
    }
}
