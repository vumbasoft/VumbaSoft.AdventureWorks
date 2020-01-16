using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IShiftValidator : IValidator
    {
        Boolean CanCreate(ShiftView view);
        Boolean CanDelete(ShiftView view);
        Boolean CanEdit(ShiftView view);
    }
}
