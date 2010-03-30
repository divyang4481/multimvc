using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    public interface IResourceProviderService:ITenantModel
    {
        IDictionary<string, string> LoadResources();
    }
}