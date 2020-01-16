using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class CurrencyRateService : BaseService, ICurrencyRateService
    {
        public CurrencyRateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<CurrencyRate, TView>(id);
        }
        public IQueryable<CurrencyRateView> GetViews()
        {
            return UnitOfWork
                .Select<CurrencyRate>()
                .To<CurrencyRateView>()
                .OrderByDescending(rate => rate.Id);
        }

        public void Create(CurrencyRateView view)
        {
            CurrencyRate rate = UnitOfWork.To<CurrencyRate>(view);

            UnitOfWork.Insert(rate);
            UnitOfWork.Commit();
        }
        public void Edit(CurrencyRateView view)
        {
            CurrencyRate rate = UnitOfWork.To<CurrencyRate>(view);

            UnitOfWork.Update(rate);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<CurrencyRate>(id);
            UnitOfWork.Commit();
        }
    }
}
