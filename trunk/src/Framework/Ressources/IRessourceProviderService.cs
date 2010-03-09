using System.Collections.Generic;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Ressources
{
    public interface IRessourceProviderService:ITenantModel
    {
        IDictionary<string, string> GetRessources();
    }
}
