using System.Collections.Generic;

namespace BA.MultiMvc.Framework.Core
{
    public interface IResourceProviderService:ITenantModel
    {
        IDictionary<string, string> GetRessources();
    }
}