using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IAddresstypeValidator : IValidator
    {
        Boolean CanCreate(AddresstypeView view);
        Boolean CanDelete(AddresstypeView view);
        Boolean CanEdit(AddresstypeView view);
    }
}
