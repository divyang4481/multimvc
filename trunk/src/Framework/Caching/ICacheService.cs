using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Caching
{
    public interface ICacheService:ITenantModel
    {
        object GetObject(string key);

        void Add(string key, object o);
    }
}
