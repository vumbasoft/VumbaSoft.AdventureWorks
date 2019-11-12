﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VumbaSoft.AdventureWorks.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    public class MinLengthAdapter : AttributeAdapterBase<MinLengthAttribute>
    {
        public MinLengthAdapter(MinLengthAttribute attribute)
            : base(attribute, null)
        {
            attribute.ErrorMessage = Validation.For("MinLength");
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes["data-val-minlength"] = GetErrorMessage(context);
            context.Attributes["data-val-minlength-min"] = Attribute.Length.ToString(CultureInfo.InvariantCulture);
        }
        public override String GetErrorMessage(ModelValidationContextBase context)
        {
            return GetErrorMessage(context.ModelMetadata);
        }
    }
}
