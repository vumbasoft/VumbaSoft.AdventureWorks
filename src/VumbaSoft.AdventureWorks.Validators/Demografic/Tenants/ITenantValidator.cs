using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ITenantValidator : IValidator
    {
        Boolean CanCreate(TenantView view);
        Boolean CanDelete(TenantView view);
        Boolean CanEdit(TenantView view);
    }
}
