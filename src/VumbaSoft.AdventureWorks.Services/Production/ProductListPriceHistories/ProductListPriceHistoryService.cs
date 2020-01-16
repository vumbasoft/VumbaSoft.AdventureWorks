using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductListPriceHistoryService : BaseService, IProductListPriceHistoryService
    {
        public ProductListPriceHistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductListPriceHistory, TView>(id);
        }
        public IQueryable<ProductListPriceHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<ProductListPriceHistory>()
                .To<ProductListPriceHistoryView>()
                .OrderByDescending(history => history.Id);
        }

        public void Create(ProductListPriceHistoryView view)
        {
            ProductListPriceHistory history = UnitOfWork.To<ProductListPriceHistory>(view);

            UnitOfWork.Insert(history);
            UnitOfWork.Commit();
        }
        public void Edit(ProductListPriceHistoryView view)
        {
            ProductListPriceHistory history = UnitOfWork.To<ProductListPriceHistory>(view);

            UnitOfWork.Update(history);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductListPriceHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
