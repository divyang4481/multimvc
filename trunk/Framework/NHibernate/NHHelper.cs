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
                    _sessionFactoryCache.Add(tenantKey,BuildSessionFactory(tenantKey));
                }
                catch (ArgumentException)
                {}
                
            }
            return _sessionFactoryCache[tenantKey];
        }

        public static Configuration GetNhConfig(string tenantKey)
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
            .AddAssembly(
                //String.Compare(tenantKey,"default",true)==0 ?"BackToOwner.Web":"BackToOwner.Web.Extensions."+ tenantKey.ToCamelCase()
                 "BackToOwner.Golf.Web"
            ) 
            .AddProperties(
                new Dictionary<string, string>()
                    {
                        {"show_sql", "True"},
                        {"current_session_context_class", IsWeb ? "web":"thread_static"}
                    }
            );
          
            
        }

       
        public static void CreateShemaExportFile(string outputfileName, string tenantKey)
        {
            var nhConfig = NHHelper.GetNhConfig(tenantKey);

            var schemaExport = new SchemaExport(nhConfig);
            schemaExport
                .SetOutputFile(outputfileName)
                .Execute(false, false, false);
        }

        public static ISessionFactory BuildSessionFactory(string tenantKey)
        {
            var nhConfig = GetNhConfig(tenantKey);
            return nhConfig.BuildSessionFactory();
            
            
        }

    }
}