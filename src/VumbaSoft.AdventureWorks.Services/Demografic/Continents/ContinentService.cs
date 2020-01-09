using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ContinentService : BaseService, IContinentService
    {
        public ContinentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Continent, TView>(id);
        }
        public IQueryable<ContinentView> GetViews()
        {
            return UnitOfWork
                .Select<Continent>()
                .To<ContinentView>()
                .OrderByDescending(continent => continent.Id);
        }

        public void Create(ContinentView view)
        {
            Continent continent = UnitOfWork.To<Continent>(view);

            UnitOfWork.Insert(continent);
            UnitOfWork.Commit();
        }
        public void Edit(ContinentView view)
        {
            Continent continent = UnitOfWork.To<Continent>(view);

            UnitOfWork.Update(continent);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Continent>(id);
            UnitOfWork.Commit();
        }
    }
}
