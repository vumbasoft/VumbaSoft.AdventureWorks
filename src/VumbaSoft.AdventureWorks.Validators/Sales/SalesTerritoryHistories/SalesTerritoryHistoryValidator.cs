using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesTerritoryHistoryValidator : BaseValidator, ISalesTerritoryHistoryValidator
    {
        public SalesTerritoryHistoryValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesTerritoryHistoryView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesTerritoryHistoryView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesTerritoryHistoryView view)
        {
            return ModelState.IsValid;
        }
    }
}
