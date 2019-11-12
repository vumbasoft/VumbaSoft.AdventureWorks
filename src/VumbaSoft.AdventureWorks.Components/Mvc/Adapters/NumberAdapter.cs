﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Globalization;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    public class NumberAdapter : AttributeAdapterBase<NumberAttribute>
    {
        public NumberAdapter(NumberAttribute attribute)
            : base(attribute, null)
        {
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes["data-val-number"] = GetErrorMessage(context);
            context.Attributes["data-val-number-scale"] = Attribute.Scale.ToString(CultureInfo.InvariantCulture);
            context.Attributes["data-val-number-precision"] = Attribute.Precision.ToString(CultureInfo.InvariantCulture);
        }
        public override String GetErrorMessage(ModelValidationContextBase context)
        {
            return GetErrorMessage(context.ModelMetadata);
        }
    }
}
