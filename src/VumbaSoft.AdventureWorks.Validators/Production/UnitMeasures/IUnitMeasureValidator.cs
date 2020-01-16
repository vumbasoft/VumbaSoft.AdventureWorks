using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IUnitMeasureValidator : IValidator
    {
        Boolean CanCreate(UnitMeasureView view);
        Boolean CanDelete(UnitMeasureView view);
        Boolean CanEdit(UnitMeasureView view);
    }
}
