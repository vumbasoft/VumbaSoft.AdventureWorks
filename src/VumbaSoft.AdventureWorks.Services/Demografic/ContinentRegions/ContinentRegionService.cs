using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ContinentRegionService : BaseService, IContinentRegionService
    {
        public ContinentRegionService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ContinentRegion, TView>(id);
        }
        public IQueryable<ContinentRegionView> GetViews()
        {
            return UnitOfWork
                .Select<ContinentRegion>()
                .To<ContinentRegionView>()
                .OrderByDescending(region => region.Id);
        }

        public void Create(ContinentRegionView view)
        {
            ContinentRegion region = UnitOfWork.To<ContinentRegion>(view);

            UnitOfWork.Insert(region);
            UnitOfWork.Commit();
        }
        public void Edit(ContinentRegionView view)
        {
            ContinentRegion region = UnitOfWork.To<ContinentRegion>(view);

            UnitOfWork.Update(region);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ContinentRegion>(id);
            UnitOfWork.Commit();
        }
    }
}
