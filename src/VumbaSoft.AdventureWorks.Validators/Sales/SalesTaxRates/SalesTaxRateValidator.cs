using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesTaxRateValidator : BaseValidator, ISalesTaxRateValidator
    {
        public SalesTaxRateValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesTaxRateView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesTaxRateView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesTaxRateView view)
        {
            return ModelState.IsValid;
        }
    }
}
