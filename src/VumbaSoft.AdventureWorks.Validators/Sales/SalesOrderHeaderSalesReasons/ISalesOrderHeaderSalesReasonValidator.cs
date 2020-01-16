using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesOrderHeaderSalesReasonValidator : IValidator
    {
        Boolean CanCreate(SalesOrderHeaderSalesReasonView view);
        Boolean CanDelete(SalesOrderHeaderSalesReasonView view);
        Boolean CanEdit(SalesOrderHeaderSalesReasonView view);
    }
}
