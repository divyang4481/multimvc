using System;
using System.Collections.Generic;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Ressources
{
    public interface IRessourceRepository:ITenantModel
    {
        IDictionary<string, string> Find(string language);
    }
}
