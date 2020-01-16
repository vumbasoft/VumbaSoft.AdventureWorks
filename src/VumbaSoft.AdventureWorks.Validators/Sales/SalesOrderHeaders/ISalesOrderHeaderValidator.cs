using VumbaSoft.AdventureWorks.Objects;
using System;

namespace VumbaSoft.AdventureWorks.Validators
{
    public interface ISalesOrderHeaderValidator : IValidator
    {
        Boolean CanCreate(SalesOrderHeaderView view);
        Boolean CanDelete(SalesOrderHeaderView view);
        Boolean CanEdit(SalesOrderHeaderView view);
    }
}
