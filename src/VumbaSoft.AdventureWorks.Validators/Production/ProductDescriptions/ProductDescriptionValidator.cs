using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductDescriptionValidator : BaseValidator, IProductDescriptionValidator
    {
        public ProductDescriptionValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductDescriptionView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductDescriptionView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductDescriptionView view)
        {
            return ModelState.IsValid;
        }
    }
}
