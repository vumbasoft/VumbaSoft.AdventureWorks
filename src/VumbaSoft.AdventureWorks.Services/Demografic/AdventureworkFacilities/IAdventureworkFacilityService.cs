using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IAdventureworkFacilityService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<AdventureworkFacilityView> GetViews();

        void Create(AdventureworkFacilityView view);
        void Edit(AdventureworkFacilityView view);
        void Delete(Int32 id);
    }
}
