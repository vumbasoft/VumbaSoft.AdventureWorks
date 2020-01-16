using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CurrencyService : BaseService, ICurrencyService
    {
        public CurrencyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<Currency, TView>(id);
        }
        public IQueryable<CurrencyView> GetViews()
        {
            return UnitOfWork
                .Select<Currency>()
                .To<CurrencyView>()
                .OrderByDescending(currency => currency.Id);
        }

        public void Create(CurrencyView view)
        {
            Currency currency = UnitOfWork.To<Currency>(view);

            UnitOfWork.Insert(currency);
            UnitOfWork.Commit();
        }
        public void Edit(CurrencyView view)
        {
            Currency currency = UnitOfWork.To<Currency>(view);

            UnitOfWork.Update(currency);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<Currency>(id);
            UnitOfWork.Commit();
        }
    }
}
