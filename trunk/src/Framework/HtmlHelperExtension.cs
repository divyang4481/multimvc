using System.IO;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BA.MultiMvc.Framework
{
    public static class HtmlHelperExtension
    {
        public static string LanguageActionLink(this HtmlHelper value, string languageCode, string linkText)
        {
            return value.ActionLink(
                linkText, "SetLanguage", "Culture",
                new
                    {
                        newLanguage = languageCode,
                        actionName = value.ViewContext.RouteData.Values["action"],
                        controllerName = value.ViewContext.RouteData.Values["controller"]
                    },
                null
                );
        }

        public static string ContentPath(this HtmlHelper value, string contentName)
        {
            var tenantKey = value.ViewContext.RouteData.GetTenantKey();
            var extensionContentUrl = "/Extensions/" + tenantKey + "/Content/" + contentName;
            var defaultContentUrl = "/Content/" + contentName;
            var extensionPath = value.ViewContext.HttpContext.Server.MapPath(extensionContentUrl);

            return File.Exists(extensionPath) ? extensionContentUrl : defaultContentUrl;
        }
    }
}