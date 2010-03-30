using System;
using System.Collections.Generic;

namespace BA.MultiMvc.Framework.Core
{
    public interface IRessourceRepository:ITenantModel
    {
        IDictionary<string, string> Find(string language);
    }
}