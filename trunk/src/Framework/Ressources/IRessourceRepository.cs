using System;
using System.Collections.Generic;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Resources
{
    public interface IRessourceRepository:ITenantModel
    {
        IDictionary<string, string> Find(string language);
    }
}
