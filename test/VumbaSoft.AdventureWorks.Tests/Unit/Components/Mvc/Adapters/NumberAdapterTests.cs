﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using VumbaSoft.AdventureWorks.Resources;
using VumbaSoft.AdventureWorks.Tests;
using System;
using System.Collections.Generic;
using Xunit;

namespace VumbaSoft.AdventureWorks.Components.Mvc.Tests
{
    public class NumberAdapterTests
    {
        private NumberAdapter adapter;
        private ClientModelValidationContext context;
        private Dictionary<String, String> attributes;

        public NumberAdapterTests()
        {
            attributes = new Dictionary<String, String>();
            adapter = new NumberAdapter(new NumberAttribute(6, 2));
            IModelMetadataProvider provider = new EmptyModelMetadataProvider();
            ModelMetadata metadata = provider.GetMetadataForProperty(typeof(AllTypesView), nameof(AllTypesView.DecimalField));

            context = new ClientModelValidationContext(new ActionContext(), metadata, provider, attributes);
        }

        [Fact]
        public void AddValidation_Number()
        {
            adapter.AddValidation(context);

            Assert.Equal(3, attributes.Count);
            Assert.Equal("2", attributes["data-val-number-scale"]);
            Assert.Equal("6", attributes["data-val-number-precision"]);
            Assert.Equal(Validation.For("Number", context.ModelMetadata.PropertyName, 4, 2), attributes["data-val-number"]);
        }

        [Fact]
        public void GetErrorMessage_Number()
        {
            String expected = Validation.For("Number", context.ModelMetadata.PropertyName, 4 , 2);
            String actual = adapter.GetErrorMessage(context);

            Assert.Equal(expected, actual);
        }
    }
}
