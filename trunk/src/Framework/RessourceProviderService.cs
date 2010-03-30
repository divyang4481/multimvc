using System;
using System.Collections.Generic;


namespace BA.MultiMvc.Framework
{
    public class ResourceProviderService : IResourceProviderService
    {
        public TenantContext Context { get; set; }
        public IResourceRepository ResourceRepository{ get; set; }
        public ICacheService CacheService { get; set; }

        public ResourceProviderService(IResourceRepository repository,ICacheService cache)
        {
            if (repository==null)
                throw new ArgumentException("repository");
            if (cache == null)
                throw new ArgumentException("cache");

            ResourceRepository = repository;
            CacheService = cache;
        }

        public IDictionary<string, string> LoadResources()
        {
            if (CacheService.GetObject("ressources") == null)
            {
                CacheService.Add("ressources", ResourceRepository.Find(Context.Language));
            }
            return (IDictionary<string, string>)CacheService.GetObject("ressources");
        }
    }
}