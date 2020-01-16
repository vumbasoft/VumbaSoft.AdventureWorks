using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq;

namespace VumbaSoft.AdventureWorks.Services
{
    public interface IShoppingCartItemService : IService
    {
        TView? Get<TView>(Int32 id) where TView : BaseView;
        IQueryable<ShoppingCartItemView> GetViews();

        void Create(ShoppingCartItemView view);
        void Edit(ShoppingCartItemView view);
        void Delete(Int32 id);
    }
}
