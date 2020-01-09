using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IContinentService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ContinentView> GetViews();

        void Create(ContinentView view);
        void Edit(ContinentView view);
        void Delete(Int32 id);
    }
}
