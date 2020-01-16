using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface ISalesTaxRateService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<SalesTaxRateView> GetViews();

        void Create(SalesTaxRateView view);
        void Edit(SalesTaxRateView view);
        void Delete(Int32 id);
    }
}
