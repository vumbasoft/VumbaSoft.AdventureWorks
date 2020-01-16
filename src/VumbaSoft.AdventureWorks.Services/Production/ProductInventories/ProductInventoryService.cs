using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ProductInventoryService : BaseService, IProductInventoryService
    {
        public ProductInventoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ProductInventory, TView>(id);
        }
        public IQueryable<ProductInventoryView> GetViews()
        {
            return UnitOfWork
                .Select<ProductInventory>()
                .To<ProductInventoryView>()
                .OrderByDescending(inventory => inventory.Id);
        }

        public void Create(ProductInventoryView view)
        {
            ProductInventory inventory = UnitOfWork.To<ProductInventory>(view);

            UnitOfWork.Insert(inventory);
            UnitOfWork.Commit();
        }
        public void Edit(ProductInventoryView view)
        {
            ProductInventory inventory = UnitOfWork.To<ProductInventory>(view);

            UnitOfWork.Update(inventory);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ProductInventory>(id);
            UnitOfWork.Commit();
        }
    }
}
