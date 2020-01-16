using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesTaxRateValidator : IValidator
    {
        Boolean CanCreate(SalesTaxRateView view);
        Boolean CanDelete(SalesTaxRateView view);
        Boolean CanEdit(SalesTaxRateView view);
    }
}
