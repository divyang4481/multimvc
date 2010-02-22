using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Components.Validator;
using BA.MultiMVC.Ressources;
using System.Collections.Specialized;
using System.Web.Routing;

namespace BA.MultiMVC.Helpers
{
    public static class ExtensionMethods
    {
        public static void AddModelErrors(
          this ModelStateDictionary modelState,
          ErrorSummary errorSummary,
          IRessourceDictionary dictionary,
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

        public static string GetLanguage(this RequestContext request, string defaultValue)
        {
                if (request.RouteData.Values.ContainsKey("language"))
                    return request.RouteData.Values["language"].ToString().ToLower();

                return defaultValue;
        }

        public static string GetTenantKey(this RequestContext request, string defaultValue)
        {
            if (request.RouteData.Values.ContainsKey("tenantKey"))
                return  request.RouteData.Values["tenantKey"].ToString().ToCamelCased();

            return defaultValue;
        }

        public static string ToCamelCased(this string s)
        {
            var camelCased = s.ToLower();
            camelCased = camelCased.Remove(0, 1);
            camelCased = s.ToUpper().Substring(0, 1) + camelCased;
            return camelCased;
        }

     
    }
}
