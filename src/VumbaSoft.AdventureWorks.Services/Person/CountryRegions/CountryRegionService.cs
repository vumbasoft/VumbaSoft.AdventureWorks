using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CountryRegionService : BaseService, ICountryRegionService
    {
        public CountryRegionService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CountryRegion, TView>(id);
        }
        public IQueryable<CountryRegionView> GetViews()
        {
            return UnitOfWork
                .Select<CountryRegion>()
                .To<CountryRegionView>()
                .OrderByDescending(region => region.Id);
        }

        public void Create(CountryRegionView view)
        {
            CountryRegion region = UnitOfWork.To<CountryRegion>(view);

            UnitOfWork.Insert(region);
            UnitOfWork.Commit();
        }
        public void Edit(CountryRegionView view)
        {
            CountryRegion region = UnitOfWork.To<CountryRegion>(view);

            UnitOfWork.Update(region);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CountryRegion>(id);
            UnitOfWork.Commit();
        }
    }
}
