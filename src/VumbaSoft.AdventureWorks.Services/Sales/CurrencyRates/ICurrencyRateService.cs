using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICurrencyRateService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CurrencyRateView> GetViews();

        void Create(CurrencyRateView view);
        void Edit(CurrencyRateView view);
        void Delete(Int32 id);
    }
}
