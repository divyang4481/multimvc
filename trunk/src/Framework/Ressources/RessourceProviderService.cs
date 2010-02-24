using System.Collections.Generic;


namespace BA.MultiMVC.Framework.Ressources
{
    public class RessourceProviderService : IRessourceProviderService
    {
        public IRessourceRepository RessourceRepository { get; set; }

        public RessourceProviderService(IRessourceRepository repository)
        {
            RessourceRepository = repository;
        }

        public IDictionary<string, string> GetRessources(string language)
        {
            return RessourceRepository.Find(language);
        }
    }
}
