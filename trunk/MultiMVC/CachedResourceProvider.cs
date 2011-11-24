using System;
using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Provider used for TenantResources <see cref="TenantResources"/>
    /// </summary>
    public abstract class CachedResourceProvider : IResourceProvider
    {
        private ICacheService CacheService { get; set; }

        public CachedResourceProvider(ICacheService cache)
        {
            if (cache == null)
                throw new ArgumentException("cache");

            CacheService = cache;

        }

        public IDictionary<string, string> GetResources()
        {
            if (CacheService.GetObject("resources") == null)
            {
                CacheService.Add("resources", GetResourcesFromDB(TenantContext.Language));
            }
            return (IDictionary<string, string>)CacheService.GetObject("resources");
        }

        protected abstract IDictionary<string, string> GetResourcesFromDB(string language);
    }
}
