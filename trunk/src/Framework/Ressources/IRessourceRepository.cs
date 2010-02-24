using BA.MultiMVC.Framework.Core;



namespace BA.MultiMVC.Framework.Ressources
{
    public interface IRessourceProvider : IRepository
    {
        #region Methods

        IRessourceDictionary GetDictionary(string tenantKey, string language);

        #endregion Methods
    }
}