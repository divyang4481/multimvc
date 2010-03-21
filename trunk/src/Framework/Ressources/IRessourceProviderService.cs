using System.Collections.Generic;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Ressources
{
    public interface IRessourceProviderService:ITenantModel
    {
        IDictionary<string, string> GetRessources();
    }
}
