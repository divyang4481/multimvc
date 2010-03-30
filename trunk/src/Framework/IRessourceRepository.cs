using System;
using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    public interface IRessourceRepository:ITenantModel
    {
        IDictionary<string, string> Find(string language);
    }
}