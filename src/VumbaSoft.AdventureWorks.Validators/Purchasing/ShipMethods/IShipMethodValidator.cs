using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface IShipMethodValidator : IValidator
    {
        Boolean CanCreate(ShipMethodView view);
        Boolean CanDelete(ShipMethodView view);
        Boolean CanEdit(ShipMethodView view);
    }
}
