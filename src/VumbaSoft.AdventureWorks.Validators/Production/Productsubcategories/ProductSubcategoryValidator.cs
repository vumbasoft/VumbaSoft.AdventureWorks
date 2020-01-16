using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductSubcategoryValidator : BaseValidator, IProductSubcategoryValidator
    {
        public ProductSubcategoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductSubcategoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductSubcategoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductSubcategoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
