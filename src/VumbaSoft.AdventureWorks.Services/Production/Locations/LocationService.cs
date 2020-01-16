using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class LocationService : BaseService, ILocationService
    {
        public LocationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Location, TView>(id);
        }
        public IQueryable<LocationView> GetViews()
        {
            return UnitOfWork
                .Select<Location>()
                .To<LocationView>()
                .OrderByDescending(location => location.Id);
        }

        public void Create(LocationView view)
        {
            Location location = UnitOfWork.To<Location>(view);

            UnitOfWork.Insert(location);
            UnitOfWork.Commit();
        }
        public void Edit(LocationView view)
        {
            Location location = UnitOfWork.To<Location>(view);

            UnitOfWork.Update(location);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Location>(id);
            UnitOfWork.Commit();
        }
    }
}
