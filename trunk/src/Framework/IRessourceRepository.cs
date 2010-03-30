using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    public interface IResourceRepository:ITenantModel
    {
        IDictionary<string, string> Find(string language);
    }
}