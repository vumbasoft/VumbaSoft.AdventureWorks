using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IContinentRegionService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ContinentRegionView> GetViews();

        void Create(ContinentRegionView view);
        void Edit(ContinentRegionView view);
        void Delete(Int32 id);
    }
}
