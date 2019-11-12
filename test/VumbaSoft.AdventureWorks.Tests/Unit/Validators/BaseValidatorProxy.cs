using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using System;
using System.Linq.Expressions;

namespace VumbaSoft.AdventureWorks.Validators.Tests
{
    public class BaseValidatorProxy : BaseValidator
    {
        public BaseValidatorProxy(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Boolean BaseIsSpecified<TView>(TView view, Expression<Func<TView, Object?>> property) where TView : BaseView
        {
            return IsSpecified(view, property);
        }
    }
}
