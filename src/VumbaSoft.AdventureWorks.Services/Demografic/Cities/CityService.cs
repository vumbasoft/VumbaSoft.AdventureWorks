using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CityService : BaseService, ICityService
    {
        public CityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<City, TView>(id);
        }
        public IQueryable<CityView> GetViews()
        {
            return UnitOfWork
                .Select<City>()
                .To<CityView>()
                .OrderByDescending(city => city.Id);
        }

        public void Create(CityView view)
        {
            City city = UnitOfWork.To<City>(view);

            UnitOfWork.Insert(city);
            UnitOfWork.Commit();
        }
        public void Edit(CityView view)
        {
            City city = UnitOfWork.To<City>(view);

            UnitOfWork.Update(city);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<City>(id);
            UnitOfWork.Commit();
        }
    }
}
