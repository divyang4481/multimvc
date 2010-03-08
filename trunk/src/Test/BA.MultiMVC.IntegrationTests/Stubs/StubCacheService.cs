using System;
using System.Collections.Generic;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.IntegrationTests.Stubs
{
    public class StubCacheService:Caching.ICacheService 
    {
        private Dictionary<string, object> hashTable;
        public StubCacheService()
        {
            hashTable = new Dictionary<string, object>();
        }


        public TenantContext Context
        {
            get; set;
        }

        public object GetObject(string key)
        {
            try
            {
                return hashTable[key];
            }
            catch
            {
                return null;
            }
        }

        public void Add(string key, object o)
        {
            hashTable.Add(key,o);
        }
    }
}
