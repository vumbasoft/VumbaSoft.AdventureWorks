using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductModelValidator : BaseValidator, IProductModelValidator
    {
        public ProductModelValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductModelView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductModelView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductModelView view)
        {
            return ModelState.IsValid;
        }
    }
}
