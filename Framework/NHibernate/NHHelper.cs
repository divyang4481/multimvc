using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg.Loquacious;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace BA.MultiMVC.Framework.NHibernate
{
    public static class NHHelper
    {

        private static Dictionary<string, ISessionFactory> _sessionFactoryCache;

        static NHHelper()
        {
            IsWeb = true; //Default value
            _sessionFactoryCache = new Dictionary<string, ISessionFactory>();
        }

        public static bool IsWeb;
        
        public static void ClearCache()
        {
            _sessionFactoryCache = new Dictionary<string, ISessionFactory>();
        }

        public static ISessionFactory GetSessionFactoryFor(string tenantKey)
        {
            if (!_sessionFactoryCache.ContainsKey(tenantKey))
            {
                try
                {
                    _sessionFactoryCache.Add(tenantKey, BuildSessionFactory(tenantKey, "BackToOwner.Golf.Web"));
                }
                catch (ArgumentException)
                {}
                
            }
            return _sessionFactoryCache[tenantKey];
        }

      

        public static Configuration GetNhConfig(string tenantKey, string assemblyName)
        {

            return new Configuration()
            .Proxy(proxy =>
                    proxy.ProxyFactoryFactory<ProxyFactoryFactory>())
            .DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.ConnectionStringName = "db" + tenantKey;
                db.BatchSize = 100;
            })
            .AddAssembly(assemblyName)
            .AddProperties(
                new Dictionary<string, string>()
                    {
                        {"show_sql", "True"},
                        {"current_session_context_class", IsWeb ? "web":"thread_static"}
                    }
            );


        }
       
        public static void CreateShemaExportFile(string outputfileName, string tenantKey, string assemblyName)
        {
            var nhConfig = NHHelper.GetNhConfig(tenantKey,assemblyName);

            var schemaExport = new SchemaExport(nhConfig);
            schemaExport
                .SetOutputFile(outputfileName)
                .Execute(false, false, false);
        }

        public static ISessionFactory BuildSessionFactory(string tenantKey, string assemblyName)
        {
            var nhConfig = GetNhConfig(tenantKey,assemblyName);
            return nhConfig.BuildSessionFactory();
            
            
        }

    }
}