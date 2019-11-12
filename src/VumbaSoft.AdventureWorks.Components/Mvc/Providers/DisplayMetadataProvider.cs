using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using VumbaSoft.AdventureWorks.Resources;
using System;

namespace VumbaSoft.AdventureWorks.Components.Mvc
{
    public class DisplayMetadataProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (context.Key.ContainerType is Type view && context.Key.MetadataKind == ModelMetadataKind.Property)
                if (Resource.ForProperty(view, context.Key.Name) is String title && title.Length > 0)
                    context.DisplayMetadata.DisplayName = () => title;
        }
    }
}
