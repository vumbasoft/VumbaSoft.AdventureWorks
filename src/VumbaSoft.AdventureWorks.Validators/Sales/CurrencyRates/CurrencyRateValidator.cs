using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class CurrencyRateValidator : BaseValidator, ICurrencyRateValidator
    {
        public CurrencyRateValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(CurrencyRateView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(CurrencyRateView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(CurrencyRateView view)
        {
            return ModelState.IsValid;
        }
    }
}
