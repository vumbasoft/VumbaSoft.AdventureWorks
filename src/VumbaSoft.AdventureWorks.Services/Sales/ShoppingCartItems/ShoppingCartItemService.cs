using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public class ShoppingCartItemService : BaseService, IShoppingCartItemService
    {
        public ShoppingCartItemService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public TView? Get<TView>(Int32 id) where TView : BaseView
        {
            return UnitOfWork.GetAs<ShoppingCartItem, TView>(id);
        }
        public IQueryable<ShoppingCartItemView> GetViews()
        {
            return UnitOfWork
                .Select<ShoppingCartItem>()
                .To<ShoppingCartItemView>()
                .OrderByDescending(item => item.Id);
        }

        public void Create(ShoppingCartItemView view)
        {
            ShoppingCartItem item = UnitOfWork.To<ShoppingCartItem>(view);

            UnitOfWork.Insert(item);
            UnitOfWork.Commit();
        }
        public void Edit(ShoppingCartItemView view)
        {
            ShoppingCartItem item = UnitOfWork.To<ShoppingCartItem>(view);

            UnitOfWork.Update(item);
            UnitOfWork.Commit();
        }
        public void Delete(Int32 id)
        {
            UnitOfWork.Delete<ShoppingCartItem>(id);
            UnitOfWork.Commit();
        }
    }
}
