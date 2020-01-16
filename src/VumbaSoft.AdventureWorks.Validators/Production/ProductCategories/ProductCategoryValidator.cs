using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductCategoryValidator : BaseValidator, IProductCategoryValidator
    {
        public ProductCategoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductCategoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductCategoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductCategoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
