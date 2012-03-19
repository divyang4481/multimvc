using System;
using System.Collections.Generic;
using System.Configuration;

namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Provide access to tenant context info
    /// </summary>
    public static class TenantContext
    {
        private static ITenantContextProvider _provider;

        /// <summary>
        /// Need to be called once - generally in the Application start to register the proper TenantContextProvider
        /// </summary>
        /// <param name="provider"></param>
        public static void SetTenantContextProvider(ITenantContextProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// The Tenant named.  
        /// </summary>
        public static string TenantKey
        {
            get
            {
                string tenantKey = _provider.TenantKey;
                return tenantKey.ToCamelCase();
            }
        }

        /// <summary>
        /// The current language
        /// </summary>
        public static string Language
        {
            get { return _provider.Language.ToLower(); }
        }
        
        /// <summary>
        /// The DB name of the tenant.
        /// </summary>
        public static string DbName
        {
            get
            {
                var conn = ConfigurationManager.ConnectionStrings["db" + TenantContext.TenantKey].ConnectionString;
                int beginIndex = conn.IndexOf("Database=") + 9;
                int endIndex = conn.IndexOf(";", beginIndex);
                return conn.Substring(beginIndex, endIndex - beginIndex);
            }
        }

        /// <summary>
        /// The connectionstring of the tenant.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["Db" + TenantContext.TenantKey].ConnectionString;
                }
                catch (NullReferenceException)
                {
                    if (ConfigurationManager.ConnectionStrings.Count >0)
                        return ConfigurationManager.ConnectionStrings[0].ConnectionString;

                    //throw new KeyNotFoundException("No connectring key found in config file!");
                    return null;
                }
            }
            
        }

        
      
    }

    public interface ITenantContextProvider
    {
        string TenantKey { get; }
        string Language { get; }
    }
}