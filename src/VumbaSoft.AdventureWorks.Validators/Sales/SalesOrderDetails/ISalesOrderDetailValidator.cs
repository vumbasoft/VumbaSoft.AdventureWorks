using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesOrderDetailValidator : IValidator
    {
        Boolean CanCreate(SalesOrderDetailView view);
        Boolean CanDelete(SalesOrderDetailView view);
        Boolean CanEdit(SalesOrderDetailView view);
    }
}
