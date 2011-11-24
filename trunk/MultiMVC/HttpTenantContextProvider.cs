using System.Web;
using System.Web.Routing;
namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Provider for the TenantContext.
    /// </summary>
    public class HttpTenantContextProvider:ITenantContextProvider
    {
        #region ITenantContextProvider Members

        /// <summary>
        /// Retrieve the TenantKey from the RouteData item with key "tenantKey"
        /// </summary>
        public string TenantKey
        {
            get
            {
                var  contextWrapper = new HttpContextWrapper(HttpContext.Current);
                var routeData = RouteTable.Routes.GetRouteData(contextWrapper);
                if (routeData != null && routeData.Values.ContainsKey("tenantKey"))
                         return routeData.Values["tenantKey"].ToString();
                
                return string.Empty;
            }
        }

        /// <summary>
        /// Retrieve the language from the RouteData item with key "language"
        /// </summary>
        public string Language
        {
            get
            {
                var contextWrapper = new HttpContextWrapper(HttpContext.Current);
                var routeData = RouteTable.Routes.GetRouteData(contextWrapper);
                return routeData != null && routeData.Values["language"] != null ? routeData.Values["language"].ToString() : "en";
            }
        }

        #endregion
    }
}
