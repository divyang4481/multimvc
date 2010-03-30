using System.Web.Mvc;
using System.Web.Routing;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Helpers
{
    public static class ApplicationHelpers
    {

        public static void ConfigureRoutes(
            RouteCollection routes, 
            string defaultTenantKey, 
            string defaultController,
            string defaultControllerNamespace ,
            string defaultLanguage,
            bool iis6CompatibilityMode)
        {
            string urlWithParameters = "{tenantKey}/{language}/{controller}X/{action}/{id}";
            urlWithParameters = iis6CompatibilityMode ? urlWithParameters.Replace("X", ".mvc") : urlWithParameters.Replace("X", string.Empty);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
            routes.MapRoute(
                defaultTenantKey,     // Route name
                urlWithParameters,     // URL with parameters
                new { tenantKey = defaultTenantKey, controller = defaultController, action = "Index", id = "" },  // Parameter defaults
                new[] { defaultControllerNamespace }
                );
            routes.MapRoute(
                "ChooseLanguage",                                              // Route name
                "{tenantKey}/{defaultLanguage}",                          // URL with parameters
                new { tenantKey = defaultTenantKey, defaultLanguage ,controller = defaultController, action = "CheckForLanguage", id = "" },
                new[] { defaultControllerNamespace }
                // Parameter defaults
                );
        }

        public static void ApplicationStart()
        {

            ControllerBuilder.Current.SetControllerFactory(
                new ExtensionControllerFactory()
                );
        }

    }
}