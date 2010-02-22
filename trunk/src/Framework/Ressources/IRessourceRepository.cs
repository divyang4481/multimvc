using BA.MultiMVC.Core;


namespace BA.MultiMVC.Ressources
{
    public interface IRessourceProvider : IRepository
    {
        #region Methods

        IRessourceDictionary GetDictionary(string tenantKey, string language);

        #endregion Methods
    }
}