using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ILocalityService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<LocalityView> GetViews();

        void Create(LocalityView view);
        void Edit(LocalityView view);
        void Delete(Int32 id);
    }
}
