using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class RegionService : BaseService, IRegionService
    {
        public RegionService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Region, TView>(id);
        }
        public IQueryable<RegionView> GetViews()
        {
            return UnitOfWork
                .Select<Region>()
                .To<RegionView>()
                .OrderByDescending(region => region.Id);
        }

        public void Create(RegionView view)
        {
            Region region = UnitOfWork.To<Region>(view);

            UnitOfWork.Insert(region);
            UnitOfWork.Commit();
        }
        public void Edit(RegionView view)
        {
            Region region = UnitOfWork.To<Region>(view);

            UnitOfWork.Update(region);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Region>(id);
            UnitOfWork.Commit();
        }
    }
}
