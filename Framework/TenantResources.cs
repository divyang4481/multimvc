using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Provide access to all resources that are specific for a particular tenant and language.
    /// </summary>
    public static class TenantResources
    {
        private static IResourceProvider _resourceProvider;
        public static void SetTenantResourceProvider(IResourceProvider resourceProvider)
        {
            _resourceProvider = resourceProvider;
        }

        public static IDictionary<string, string> Values
        {
            get { return _resourceProvider.GetResources(); }
        }

    }
}
