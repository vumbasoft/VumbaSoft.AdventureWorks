using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductCostHistoryService : BaseService, IProductCostHistoryService
    {
        public ProductCostHistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductCostHistory, TView>(id);
        }
        public IQueryable<ProductCostHistoryView> GetViews()
        {
            return UnitOfWork
                .Select<ProductCostHistory>()
                .To<ProductCostHistoryView>()
                .OrderByDescending(history => history.Id);
        }

        public void Create(ProductCostHistoryView view)
        {
            ProductCostHistory history = UnitOfWork.To<ProductCostHistory>(view);

            UnitOfWork.Insert(history);
            UnitOfWork.Commit();
        }
        public void Edit(ProductCostHistoryView view)
        {
            ProductCostHistory history = UnitOfWork.To<ProductCostHistory>(view);

            UnitOfWork.Update(history);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductCostHistory>(id);
            UnitOfWork.Commit();
        }
    }
}
