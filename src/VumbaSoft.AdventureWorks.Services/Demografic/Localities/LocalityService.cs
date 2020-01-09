using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class LocalityService : BaseService, ILocalityService
    {
        public LocalityService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Locality, TView>(id);
        }
        public IQueryable<LocalityView> GetViews()
        {
            return UnitOfWork
                .Select<Locality>()
                .To<LocalityView>()
                .OrderByDescending(locality => locality.Id);
        }

        public void Create(LocalityView view)
        {
            Locality locality = UnitOfWork.To<Locality>(view);

            UnitOfWork.Insert(locality);
            UnitOfWork.Commit();
        }
        public void Edit(LocalityView view)
        {
            Locality locality = UnitOfWork.To<Locality>(view);

            UnitOfWork.Update(locality);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Locality>(id);
            UnitOfWork.Commit();
        }
    }
}
