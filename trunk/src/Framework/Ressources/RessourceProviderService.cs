using System.Collections.Generic;


namespace BA.MultiMVC.Framework.Ressources
{
    public class RessourceProviderService : IRessourceProviderService
    {
        public Core.TenantContext Context { get; set; }
        public IRessourceRepository RessourceRepository { get; set; }

        public RessourceProviderService(IRessourceRepository repository)
        {
            RessourceRepository = repository;
        }

        public IDictionary<string, string> GetRessources()
        {
            return RessourceRepository.Find(Context.Language);
        }
    }
}
