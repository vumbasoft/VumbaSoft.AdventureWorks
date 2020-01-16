using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ICurrencyService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<CurrencyView> GetViews();

        void Create(CurrencyView view);
        void Edit(CurrencyView view);
        void Delete(Int32 id);
    }
}
