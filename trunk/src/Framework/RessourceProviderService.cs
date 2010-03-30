using System;
using System.Collections.Generic;


namespace BA.MultiMvc.Framework
{
    public class RessourceProviderService : IResourceProviderService
    {
        public TenantContext Context { get; set; }
        public IRessourceRepository RessourceRepository { get; set; }
        public ICacheService CacheService { get; set; }

        public RessourceProviderService(IRessourceRepository repository,ICacheService cache)
        {
            if (repository==null)
                throw new ArgumentException("repository");
            if (cache == null)
                throw new ArgumentException("cache");

            RessourceRepository = repository;
            CacheService = cache;
        }

        public IDictionary<string, string> GetRessources()
        {
            if (CacheService.GetObject("ressources") == null)
            {
                CacheService.Add("ressources", RessourceRepository.Find(Context.Language));
            }
            return (IDictionary<string, string>)CacheService.GetObject("ressources");
        }
    }
}