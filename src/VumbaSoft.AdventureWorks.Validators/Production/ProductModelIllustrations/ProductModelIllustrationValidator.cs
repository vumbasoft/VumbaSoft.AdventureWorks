using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductModelIllustrationValidator : BaseValidator, IProductModelIllustrationValidator
    {
        public ProductModelIllustrationValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductModelIllustrationView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductModelIllustrationView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductModelIllustrationView view)
        {
            return ModelState.IsValid;
        }
    }
}
