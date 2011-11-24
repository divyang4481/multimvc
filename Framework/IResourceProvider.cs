using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Defines a generic contract for a ResourceProvider
    /// </summary>
    public interface IResourceProvider:ITenantModel
    {
        IDictionary<string, string> GetResources();
    }
}