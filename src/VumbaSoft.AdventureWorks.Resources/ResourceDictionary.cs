using System;
using System.Collections.Concurrent;

namespace VumbaSoft.AdventureWorks.Resources
{
    internal class ResourceDictionary : ConcurrentDictionary<String, String?>
    {
        public ResourceDictionary()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
