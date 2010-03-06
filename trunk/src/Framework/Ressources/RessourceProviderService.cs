using System.Collections.Generic;
using BA.MultiMVC.Framework.Caching;


namespace BA.MultiMVC.Framework.Ressources
{
    public class RessourceProviderService : IRessourceProviderService
    {
        public Core.TenantContext Context { get; set; }
        public IRessourceRepository RessourceRepository { get; set; }
        public ICacheService CacheService { get; set; }

        public RessourceProviderService(IRessourceRepository repository,ICacheService cache)
        {
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
