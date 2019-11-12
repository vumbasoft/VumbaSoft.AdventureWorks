﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    [HtmlTargetElement("link", Attributes = "action", TagStructure = TagStructure.WithoutEndTag)]
    public class AppStyleTagHelper : TagHelper
    {
        public override Int32 Order => -2000;

        public String? Action { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        private IWebHostEnvironment Environment { get; }

        private Func<ActionContext?, IUrlHelper> UrlFactory { get; }

        private static ConcurrentDictionary<String, String?> Styles { get; }

        static AppStyleTagHelper()
        {
            Styles = new ConcurrentDictionary<String, String?>();
        }
        public AppStyleTagHelper(IWebHostEnvironment environment, IUrlHelperFactory url)
        {
            Environment = environment;
            UrlFactory = url.GetUrlHelper;
        }

        public override void Process(TagHelperContext? context, TagHelperOutput output)
        {
            String path = FormPath();

            if (!Styles.ContainsKey(path))
            {
                Styles[path] = null;

                if (ScriptsAvailable(path))
                    Styles[path] = UrlFactory(ViewContext).Content($"~/css/application/{path}");
            }

            if (Styles[path] == null)
                output.TagName = null;
            else
                output.Attributes.SetAttribute("href", Styles[path]);
        }

        private Boolean ScriptsAvailable(String path)
        {
            return File.Exists(Path.Combine(Environment.WebRootPath, $"css/application/{path}"));
        }
        private String FormPath()
        {
            String extension = Environment.IsDevelopment() ? ".css" : ".min.css";
            RouteValueDictionary route = ViewContext?.RouteData.Values ?? new RouteValueDictionary();

            return $"{(route["Area"] == null ? null : $"{route["Area"]}/")}{route["controller"]}/{Action}{extension}".ToLower();
        }
    }
}
