﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using NSubstitute;
using System;
using Xunit;

namespace VumbaSoft.AdventureWorks.Components.Mvc.Tests
{
    public class LanguageFilterTests
    {
        [Fact]
        public void OnActionExecuting_SetsCurrentLanguage()
        {
            ActionContext action = new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor());
            ResourceExecutingContext context = new ResourceExecutingContext(action, Array.Empty<IFilterMetadata>(), Array.Empty<IValueProviderFactory>());
            ILanguages languages = Substitute.For<ILanguages>();
            context.RouteData.Values["language"] = "lt";
            languages["lt"].Returns(new Language());

            new LanguageFilter(languages).OnResourceExecuting(context);

            Language actual = languages.Current;
            Language expected = languages["lt"];

            Assert.Equal(expected, actual);
        }
    }
}
