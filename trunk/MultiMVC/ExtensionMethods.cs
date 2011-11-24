using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections.Specialized;
using System.Web.Routing;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Generic helper methods  
    /// </summary>
    public static class ExtensionMethods
    {
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
            return routeData.Values.ContainsKey("language") ? routeData.Values["language"].ToString().ToUpperInvariant() : defaultValue;
        }

        public static string GetTenantKey(this RouteData routeData)
        {
            const string defaultValue = "Default";
            return routeData.Values.ContainsKey("tenantKey") ? routeData.Values["tenantKey"].ToString().ToCamelCase() : defaultValue;
        }

        public static string ToCamelCase(this string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            var camelCased = value.ToLowerInvariant();
            camelCased = camelCased.Remove(0, 1);
            camelCased = value.ToUpperInvariant().Substring(0, 1) + camelCased;
            return camelCased;
        }

        public static IList<PropertyInfo> FindProperties(this object subject, Type filter)
        {
            var ret = new List<PropertyInfo>();
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