using System;
using System.Collections.Generic;
using System.Configuration;
using BA.MultiMvc.Framework.Ressources;

namespace BA.MultiMvc.Framework.Core
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
                    _connectionString = GetConnectionString();
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

       protected virtual string GetConnectionString()
       {
           
           try
           {
               return ConfigurationManager.ConnectionStrings[TenantKey + "Connection"].ConnectionString;
           }
           catch (NullReferenceException)
           {
               if (ConfigurationManager.ConnectionStrings.Count >0)
                     return ConfigurationManager.ConnectionStrings[0].ConnectionString;

               throw new ApplicationException("No connectring found in config file!");
           }
       }

       
      
    }
}
