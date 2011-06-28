using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    public interface IResourceProvider:ITenantModel
    {
        IDictionary<string, string> GetResources();
    }
}