using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IStoreValidator : IValidator
    {
        Boolean CanCreate(StoreView view);
        Boolean CanDelete(StoreView view);
        Boolean CanEdit(StoreView view);
    }
}
