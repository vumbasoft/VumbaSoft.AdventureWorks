using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesTerritoryValidator : IValidator
    {
        Boolean CanCreate(SalesTerritoryView view);
        Boolean CanDelete(SalesTerritoryView view);
        Boolean CanEdit(SalesTerritoryView view);
    }
}
