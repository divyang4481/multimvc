using System.Collections.Generic;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Resources
{
    public interface IResourceProviderService:ITenantModel
    {
        IDictionary<string, string> GetRessources();
    }
}
