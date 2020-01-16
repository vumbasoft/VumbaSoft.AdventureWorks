using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesOrderDetailValidator : BaseValidator, ISalesOrderDetailValidator
    {
        public SalesOrderDetailValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesOrderDetailView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesOrderDetailView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesOrderDetailView view)
        {
            return ModelState.IsValid;
        }
    }
}
