using Microsoft.AspNetCore.Mvc.ModelBinding;
using VumbaSoft.AdventureWorks.Components.Notifications;
using VumbaSoft.AdventureWorks.Data.Core;
using VumbaSoft.AdventureWorks.Objects;
using VumbaSoft.AdventureWorks.Resources;
using System;
using System.Linq.Expressions;

namespace VumbaSoft.AdventureWorks.Validators
{
    public abstract class BaseValidator : IValidator
    {
        public ModelStateDictionary ModelState { get; set; }
        public Int32 CurrentAccountId { get; set; }
        public Alerts Alerts { get; set; }

        protected IUnitOfWork UnitOfWork { get; }

        protected BaseValidator(IUnitOfWork unitOfWork)
        {
            ModelState = new ModelStateDictionary();
            UnitOfWork = unitOfWork;
            Alerts = new Alerts();
        }

        protected Boolean IsSpecified<TView>(TView view, Expression<Func<TView, Object?>> property) where TView : BaseView
        {
            Boolean isSpecified = property.Compile().Invoke(view) != null;

            if (!isSpecified)
            {
                if (property.Body is UnaryExpression unary)
                    ModelState.AddModelError(property, Validation.For("Required", Resource.ForProperty(unary.Operand)));
                else
                    ModelState.AddModelError(property, Validation.For("Required", Resource.ForProperty(property)));
            }

            return isSpecified;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
