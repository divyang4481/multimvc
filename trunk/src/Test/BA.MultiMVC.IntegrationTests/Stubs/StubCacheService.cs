using System.Collections.Generic;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.IntegrationTests.Stubs
{
    public class StubCacheService: ICacheService 
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
