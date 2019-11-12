using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VumbaSoft.AdventureWorks.Resources;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    public class DateValidator : IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes["data-val-date"] = Validation.For("Date", context.ModelMetadata.GetDisplayName());
        }
    }
}
