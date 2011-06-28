using System;
using System.Collections.Generic;
using System.Linq;
using BA.MultiMvc.Sample.Models.Infrastructure.Linq;


namespace BA.MultiMvc.Framework
{
    public class ResourceProvider : IResourceProvider
    {
        public TenantContext Context { get; set; }
        public ICacheService CacheService { get; set; }

        public ResourceProvider(ICacheService cache)
        {
            if (cache == null)
                throw new ArgumentException("cache");

            CacheService = cache;

        }

        public IDictionary<string, string> GetResources()
        {
            if (CacheService.GetObject("ressources") == null)
            {
                CacheService.Add("ressources", getRessources(Context.Language));
            }
            return (IDictionary<string, string>)CacheService.GetObject("ressources");
        }

        protected virtual System.Collections.Generic.IDictionary<string, string> getRessources(string language)
        {
            var _db = new DBDataContext(this.Context.ConnectionString);
            var query = from p in _db.Ressources
                        where p.RessourceLanguage == language
                        select p;

            Dictionary<string, string> ressources = new Dictionary<string, string>();
            foreach (var item in query)
            {
                ressources.Add(item.RessourceKey, item.RessourceValue);
            }
            return ressources;
        }
    }
}