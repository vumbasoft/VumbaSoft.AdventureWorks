using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ProductModelProductDescriptionCultureValidator : BaseValidator, IProductModelProductDescriptionCultureValidator
    {
        public ProductModelProductDescriptionCultureValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ProductModelProductDescriptionCultureView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ProductModelProductDescriptionCultureView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ProductModelProductDescriptionCultureView view)
        {
            return ModelState.IsValid;
        }
    }
}
