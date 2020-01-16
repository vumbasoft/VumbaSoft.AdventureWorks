using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesTerritoryValidator : BaseValidator, ISalesTerritoryValidator
    {
        public SalesTerritoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesTerritoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesTerritoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesTerritoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
