using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IBillOfMaterialValidator : IValidator
    {
        Boolean CanCreate(BillOfMaterialView view);
        Boolean CanDelete(BillOfMaterialView view);
        Boolean CanEdit(BillOfMaterialView view);
    }
}
