using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IProductReviewValidator : IValidator
    {
        Boolean CanCreate(ProductReviewView view);
        Boolean CanDelete(ProductReviewView view);
        Boolean CanEdit(ProductReviewView view);
    }
}
