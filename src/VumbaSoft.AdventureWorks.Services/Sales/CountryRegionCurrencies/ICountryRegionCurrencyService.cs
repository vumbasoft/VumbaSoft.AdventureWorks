using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICountryRegionCurrencyService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CountryRegionCurrencyView> GetViews();

        void Create(CountryRegionCurrencyView view);
        void Edit(CountryRegionCurrencyView view);
        void Delete(Int32 id);
    }
}
