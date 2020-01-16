using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class ShipMethodValidator : BaseValidator, IShipMethodValidator
    {
        public ShipMethodValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(ShipMethodView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(ShipMethodView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(ShipMethodView view)
        {
            return ModelState.IsValid;
        }
    }
}
