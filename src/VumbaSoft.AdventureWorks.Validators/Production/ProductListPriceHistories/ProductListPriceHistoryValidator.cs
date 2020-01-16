using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductListPriceHistoryValidator : BaseValidator, IProductListPriceHistoryValidator
    {
        public ProductListPriceHistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductListPriceHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductListPriceHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductListPriceHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
