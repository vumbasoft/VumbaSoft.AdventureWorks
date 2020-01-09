using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICountryService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CountryView> GetViews();

        void Create(CountryView view);
        void Edit(CountryView view);
        void Delete(Int32 id);
    }
}
