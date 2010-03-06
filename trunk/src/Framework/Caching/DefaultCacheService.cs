using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BA.MultiMVC.Framework.Caching
{
    public class DefaultCacheService:ICacheService 
    {

        #region ICacheService Members

        public object GetObject(string key)
        {
            throw new NotImplementedException();
        }

        public void Add(string key, object o)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IService Members

        public BA.MultiMVC.Framework.Core.TenantContext Context
        {
            get;
            set;
        }

        #endregion
    }
}
