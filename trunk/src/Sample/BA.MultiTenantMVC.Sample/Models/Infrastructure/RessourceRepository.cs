using System.Linq;
using BA.MultiMVC.Ressources;

namespace BA.MultiMVC.Sample.Models.Infrastructure
{
    public class RessourceRepository :  IRessourceProvider
    {
        #region Methods

        public IRessourceDictionary GetDictionary(string controller, string language)
        {
            //Todo: change signature to retrieve all ressources & implement caching
            var ressources = new RessourceDictionary();
            return ressources;
        }

        public IRessourceDictionary GetDictionary(System.Web.Routing.RouteData routeData)
        {
            var controller = routeData.Values["controller"].ToString();
            var language = routeData.Values["language"].ToString();

            return this.GetDictionary(controller, language);
        }

        public IRessourceDictionary GetErrorMessagesDictionary(string language)
        {
            const string controller = "ErrorMessages";

            return this.GetDictionary(controller, language);
        }

        #endregion Methods


        #region Properties
        public string ConnectionString { get; set; }

        #endregion
    }
}