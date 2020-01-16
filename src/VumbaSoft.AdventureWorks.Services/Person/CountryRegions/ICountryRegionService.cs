using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICountryRegionService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CountryRegionView> GetViews();

        void Create(CountryRegionView view);
        void Edit(CountryRegionView view);
        void Delete(Int32 id);
    }
}
