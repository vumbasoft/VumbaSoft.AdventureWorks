using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesPersonQuotaHistoryValidator : IValidator
    {
        Boolean CanCreate(SalesPersonQuotaHistoryView view);
        Boolean CanDelete(SalesPersonQuotaHistoryView view);
        Boolean CanEdit(SalesPersonQuotaHistoryView view);
    }
}
