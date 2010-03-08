using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BA.MultiMVC.Framework.Caching
{
    public class DefaultCacheService:ICacheService 
    {
        public DefaultCacheService()
        {
            CacheTimeSeconds = 60;
        }

        public object GetObject(string key)
        {
            return HttpRuntime.Cache[key];
        }

        public void Add(string key, object o)
        {
            DateTime expirationTime = DateTime.Now.AddSeconds(CacheTimeSeconds);
            HttpRuntime.Cache.Add(
                key,
                o,
                null,
                DateTime.Now.AddSeconds(CacheTimeSeconds),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Normal,
                null
                );
        }

        public int CacheTimeSeconds
        {
            get;
            set;
        }

        public BA.MultiMVC.Framework.Core.TenantContext Context
        {
            get;
            set;
        }
    }
}
