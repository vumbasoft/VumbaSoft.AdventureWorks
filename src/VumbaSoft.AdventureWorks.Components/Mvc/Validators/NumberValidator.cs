using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VumbaSoft.AdventureWorks.Resources;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    public class NumberValidator : IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val-number"))
                context.Attributes["data-val-number"] = Validation.For("Numeric", context.ModelMetadata.GetDisplayName());
        }
    }
}
