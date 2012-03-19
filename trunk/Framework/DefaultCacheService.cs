using System;
using System.Web;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Caches objects per Tenant and Language.
    /// Used primarly by the Resource provider to cache the Dictionary containing the site resources.<see cref="TenantResources"/>
    /// </summary>
    public class DefaultCacheService:ICacheService 
    {
        public DefaultCacheService()
        {
            CacheTimeSeconds = 120;
        }

        public object GetObject(string key)
        {
            return HttpRuntime.Cache[ConstructFullKeyName(key)];
        }

        public void Clear(string key)
        {
            HttpRuntime.Cache.Remove(ConstructFullKeyName(key));
        }

        public void Add(string key, object value)
        {
            HttpRuntime.Cache.Add(
                ConstructFullKeyName(key),
                value,
                null,
                DateTime.Now.AddSeconds(CacheTimeSeconds),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Normal,
                null
                );
        }

        public virtual string KeyPrefix
        {
            get
            {
                return TenantContext.TenantKey + "_" + TenantContext.Language; 
            }
        }

        public int CacheTimeSeconds
        {
            get;
            set;
        }

        private string ConstructFullKeyName(string keySuffix)
        {
            return KeyPrefix + "_" + keySuffix;
        }
    }
}