using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMVC.Framework.NHibernate;
using NHibernate.Linq;

namespace BA.MultiMvc.Framework.NHibernate
{
    public class NHCachedResourceProvider : CachedResourceProvider
    {
        public NHCachedResourceProvider(ICacheService cache)
            : base(cache)
        {
        }

        protected override IDictionary<string, string> GetResourcesFromDB(string language)
        {
            var session = NHHelper.GetSessionFactoryFor(TenantContext.TenantKey).GetCurrentSession();
            var query = from r in session.Query<Resource>()
                        where r.Language == language
                        select new { r.Label, r.Value };
            var ret = new Dictionary<string, string>();
            foreach (var item in query)
            {
                if (!ret.ContainsKey(item.Label))
                {
                    ret.Add(item.Label, item.Value);
                }
            }
            return ret;
        }
    }
}
