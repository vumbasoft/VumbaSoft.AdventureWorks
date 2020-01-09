using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CountryService : BaseService, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Country, TView>(id);
        }
        public IQueryable<CountryView> GetViews()
        {
            return UnitOfWork
                .Select<Country>()
                .To<CountryView>()
                .OrderByDescending(country => country.Id);
        }

        public void Create(CountryView view)
        {
            Country country = UnitOfWork.To<Country>(view);

            UnitOfWork.Insert(country);
            UnitOfWork.Commit();
        }
        public void Edit(CountryView view)
        {
            Country country = UnitOfWork.To<Country>(view);

            UnitOfWork.Update(country);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Country>(id);
            UnitOfWork.Commit();
        }
    }
}
