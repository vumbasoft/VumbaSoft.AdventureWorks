using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductValidator : BaseValidator, IProductValidator
    {
        public ProductValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductView view)
        {
            return ModelState.IsValid;
        }
    }
}
