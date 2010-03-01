using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Caching
{
    public interface ICacheService:IService
    {
        object GetObject(string p);
    }
}
