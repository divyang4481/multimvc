using System.Web.Mvc;
using System.Web.Routing;
using BA.MultiMvc.Sample;

namespace BA.MultiMvc.Framework.Core.MultiMvc.Sample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "ChooseLanguage",                                              // Route name
                "{tenantKey}",                          // URL with parameters
                new { tenantKey = "default", controller = "Home", action = "CheckForLanguage", id = "" }
                // Parameter defaults
                );
            routes.MapRoute(
                "FullyQualified", // Route name
                "{tenantKey}/{language}/{controller}/{action}/{id}", // URL with parameters
                new { tenantKey = "default", language = "en",controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            
                );
        }

        public static void RegisterViewEngines(ViewEngineCollection viewEngines)  
        {  
            viewEngines.Clear();  
            viewEngines.Add(new MultiWebFormViewEngine());  
        }  


        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterViewEngines(ViewEngines.Engines);
            Bootstrapper.ConfigureStructureMap(Bootstrapper.ExtensionPath);
            ControllerBuilder.Current.SetControllerFactory(
              new ExtensionControllerFactory()
              );
        }
    }
}