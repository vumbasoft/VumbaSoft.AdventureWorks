using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IShoppingCartItemValidator : IValidator
    {
        Boolean CanCreate(ShoppingCartItemView view);
        Boolean CanDelete(ShoppingCartItemView view);
        Boolean CanEdit(ShoppingCartItemView view);
    }
}
