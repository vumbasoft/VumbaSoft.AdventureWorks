using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IRegionService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<RegionView> GetViews();

        void Create(RegionView view);
        void Edit(RegionView view);
        void Delete(Int32 id);
    }
}
