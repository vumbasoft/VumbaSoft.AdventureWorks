using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IStoreContactValidator : IValidator
    {
        Boolean CanCreate(StoreContactView view);
        Boolean CanDelete(StoreContactView view);
        Boolean CanEdit(StoreContactView view);
    }
}
