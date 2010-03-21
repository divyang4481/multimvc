using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Caching
{
    public interface ICacheService:ITenantModel
    {
        object GetObject(string key);

        void Add(string key, object o);
    }
}
