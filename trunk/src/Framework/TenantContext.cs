using System;
using System.Collections.Generic;
using System.Configuration;

namespace BA.MultiMvc.Framework
{
    public class TenantContext
    {
        private string _connectionString;

        public TenantContext(string tenantKey, string language)
        {
            TenantKey = tenantKey;
            Language = language;
        }

        public string TenantKey { get; set; }
        public string Language { get; set; }
        
        public string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                    _connectionString = BuildConnectionString();
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        protected virtual string BuildConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[TenantKey + "Connection"].ConnectionString;
            }
            catch (NullReferenceException)
            {
                if (ConfigurationManager.ConnectionStrings.Count >0)
                    return ConfigurationManager.ConnectionStrings[0].ConnectionString;

                throw new KeyNotFoundException("No connectring key found in config file!");
            }
        }      
      
    }
}