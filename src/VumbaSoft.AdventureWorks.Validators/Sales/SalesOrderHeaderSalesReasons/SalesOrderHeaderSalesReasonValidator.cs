using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public class SalesOrderHeaderSalesReasonValidator : BaseValidator, ISalesOrderHeaderSalesReasonValidator
    {
        public SalesOrderHeaderSalesReasonValidator(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean CanCreate(SalesOrderHeaderSalesReasonView view)
        {
            return ModelState.IsValid;
        }

        public Boolean CanDelete(SalesOrderHeaderSalesReasonView view)
        {
            return ModelState.IsValid;
        }


        public Boolean CanEdit(SalesOrderHeaderSalesReasonView view)
        {
            return ModelState.IsValid;
        }
    }
}
