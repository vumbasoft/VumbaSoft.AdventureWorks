using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CurrencyValidator : BaseValidator, ICurrencyValidator
    {
        public CurrencyValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CurrencyView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CurrencyView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CurrencyView view)
        {
            return ModelState.IsValid;
        }
    }
}
