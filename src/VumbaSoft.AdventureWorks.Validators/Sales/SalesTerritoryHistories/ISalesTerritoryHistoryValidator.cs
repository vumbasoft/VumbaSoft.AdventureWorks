using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesTerritoryHistoryValidator : IValidator
    {
        Boolean CanCreate(SalesTerritoryHistoryView view);
        Boolean CanDelete(SalesTerritoryHistoryView view);
        Boolean CanEdit(SalesTerritoryHistoryView view);
    }
}
