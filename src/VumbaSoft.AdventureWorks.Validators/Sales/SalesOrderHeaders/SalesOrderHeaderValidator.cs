using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesOrderHeaderValidator : BaseValidator, ISalesOrderHeaderValidator
    {
        public SalesOrderHeaderValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesOrderHeaderView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesOrderHeaderView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesOrderHeaderView view)
        {
            return ModelState.IsValid;
        }
    }
}
