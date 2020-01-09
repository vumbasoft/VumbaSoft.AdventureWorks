using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class AdventureworkFacilityService : BaseService, IAdventureworkFacilityService
    {
        public AdventureworkFacilityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<AdventureworkFacility, TView>(id);
        }
        public IQueryable<AdventureworkFacilityView> GetViews()
        {
            return UnitOfWork
                .Select<AdventureworkFacility>()
                .To<AdventureworkFacilityView>()
                .OrderByDescending(facility => facility.Id);
        }

        public void Create(AdventureworkFacilityView view)
        {
            AdventureworkFacility facility = UnitOfWork.To<AdventureworkFacility>(view);

            UnitOfWork.Insert(facility);
            UnitOfWork.Commit();
        }
        public void Edit(AdventureworkFacilityView view)
        {
            AdventureworkFacility facility = UnitOfWork.To<AdventureworkFacility>(view);

            UnitOfWork.Update(facility);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<AdventureworkFacility>(id);
            UnitOfWork.Commit();
        }
    }
}
