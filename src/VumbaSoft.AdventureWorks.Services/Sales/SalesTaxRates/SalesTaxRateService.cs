using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class SalesTaxRateService : BaseService, ISalesTaxRateService
    {
        public SalesTaxRateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<SalesTaxRate, TView>(id);
        }
        public IQueryable<SalesTaxRateView> GetViews()
        {
            return UnitOfWork
                .Select<SalesTaxRate>()
                .To<SalesTaxRateView>()
                .OrderByDescending(rate => rate.Id);
        }

        public void Create(SalesTaxRateView view)
        {
            SalesTaxRate rate = UnitOfWork.To<SalesTaxRate>(view);

            UnitOfWork.Insert(rate);
            UnitOfWork.Commit();
        }
        public void Edit(SalesTaxRateView view)
        {
            SalesTaxRate rate = UnitOfWork.To<SalesTaxRate>(view);

            UnitOfWork.Update(rate);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<SalesTaxRate>(id);
            UnitOfWork.Commit();
        }
    }
}
