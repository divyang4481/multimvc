using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Castle.Components.Validator;
using System.Collections.Specialized;
using System.Web.Routing;
using System.Web.Mvc.Html;
using System.IO;

namespace BA.MultiMVC.Framework.Helpers
{
    public static class ExtensionMethods
    {
        public static void AddModelErrors(
          this ModelStateDictionary modelState,
          ErrorSummary errorSummary,
          IDictionary<string,string> dictionary,
          NameValueCollection data)
        {
            if (errorSummary != null && errorSummary.HasError)
            {
                foreach (var propertyInError in errorSummary.InvalidProperties)
                {
                    foreach (var message in errorSummary.GetErrorsForProperty(propertyInError))
                    {
                        try
                        {
                            modelState.AddModelError(propertyInError, dictionary[message]);
                            modelState.SetModelValue(
                                propertyInError,
                                new ValueProviderResult(GetValue(data, propertyInError),
                                    ""
                                    , System.Globalization.CultureInfo.CurrentCulture
                                        )
                                    );
                        }
                        catch (KeyNotFoundException ex)
                        {
                            throw new ApplicationException(
                                String.Format("The key {0} was not found in Dictionary", message)
                                , ex
                                );
                        }
                    }
                }
            }
        }

        public static string GetValue(this NameValueCollection collection, string index)
        {
            var originalValue = "";
            if (collection != null)
            {
                originalValue = collection[index];
            }
            return originalValue;
        }

        public static string GetLanguage(this RouteData routeData)
        {
            const string defaultValue = "en";
            return routeData.Values.ContainsKey("language") ? routeData.Values["language"].ToString().ToLower() : defaultValue;
        }

        public static string GetTenantKey(this RouteData routeData)
        {
            const string defaultValue = "Default";
            return routeData.Values.ContainsKey("tenantKey") ? routeData.Values["tenantKey"].ToString().ToCamelCased() : defaultValue;
        }

        public static string ToCamelCased(this string s)
        {
            var camelCased = s.ToLower();
            camelCased = camelCased.Remove(0, 1);
            camelCased = s.ToUpper().Substring(0, 1) + camelCased;
            return camelCased;
        }

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

        public static IList<PropertyInfo> FindProperties(this object subject, Type filter)
        {
            Object result = null;
            var ret = new System.Collections.Generic.List<PropertyInfo>();
            var properties = subject.GetType().GetProperties();
            foreach (var property in properties)
            {
                Type t = property.PropertyType;
                if (filter.IsAssignableFrom(t))
                    ret.Add(property);
            }
            return ret;
        }

     
    }
}
