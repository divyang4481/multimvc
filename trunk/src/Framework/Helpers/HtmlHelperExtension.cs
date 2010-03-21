using System.IO;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BA.MultiMvc.Framework.Helpers
{
    public static class HtmlHelperExtension
    {
        public static string LanguageActionLink(this HtmlHelper h, string languageCode, string linkText)
        {
            return h.ActionLink(
                linkText, "SetLanguage", "Culture",
                new
                {
                    newLanguage = languageCode,
                    actionName = h.ViewContext.RouteData.Values["action"],
                    controllerName = h.ViewContext.RouteData.Values["controller"]
                },
                null
                );
        }

        public static string ContentPath(this HtmlHelper h, string contentName)
        {
            var tenantKey = h.ViewContext.RouteData.GetTenantKey();
            var extensionContentUrl = "/Extensions/" + tenantKey + "/Content/" + contentName;
            var defaultContentUrl = "/Content/" + contentName;
            var extensionPath = h.ViewContext.HttpContext.Server.MapPath(extensionContentUrl);

            return File.Exists(extensionPath) ? extensionContentUrl : defaultContentUrl;
        }
    }
}
