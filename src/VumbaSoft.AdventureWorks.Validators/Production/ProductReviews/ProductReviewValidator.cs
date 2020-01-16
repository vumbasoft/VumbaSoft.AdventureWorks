using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductReviewValidator : BaseValidator, IProductReviewValidator
    {
        public ProductReviewValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductReviewView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductReviewView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductReviewView view)
        {
            return ModelState.IsValid;
        }
    }
}
