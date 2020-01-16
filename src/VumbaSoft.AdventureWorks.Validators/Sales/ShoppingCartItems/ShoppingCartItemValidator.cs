using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ShoppingCartItemValidator : BaseValidator, IShoppingCartItemValidator
    {
        public ShoppingCartItemValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ShoppingCartItemView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ShoppingCartItemView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ShoppingCartItemView view)
        {
            return ModelState.IsValid;
        }
    }
}
