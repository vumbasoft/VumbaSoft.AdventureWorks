using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CountryRegionCurrencyService : BaseService, ICountryRegionCurrencyService
    {
        public CountryRegionCurrencyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CountryRegionCurrency, TView>(id);
        }
        public IQueryable<CountryRegionCurrencyView> GetViews()
        {
            return UnitOfWork
                .Select<CountryRegionCurrency>()
                .To<CountryRegionCurrencyView>()
                .OrderByDescending(currency => currency.Id);
        }

        public void Create(CountryRegionCurrencyView view)
        {
            CountryRegionCurrency currency = UnitOfWork.To<CountryRegionCurrency>(view);

            UnitOfWork.Insert(currency);
            UnitOfWork.Commit();
        }
        public void Edit(CountryRegionCurrencyView view)
        {
            CountryRegionCurrency currency = UnitOfWork.To<CountryRegionCurrency>(view);

            UnitOfWork.Update(currency);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CountryRegionCurrency>(id);
            UnitOfWork.Commit();
        }
    }
}
