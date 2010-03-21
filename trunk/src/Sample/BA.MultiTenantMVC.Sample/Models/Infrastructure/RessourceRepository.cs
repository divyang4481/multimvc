using System.Collections.Generic;
using BA.MultiMvc.Framework.Ressources;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;
using System.Linq;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiTenantMVC.Sample.Models.Infrastructure
{
    public class RessourceRepository :  IRessourceRepository
    {
        protected DBDataContext _db;

        public RessourceRepository()
        {}

        #region IRessourceRepository Members

        public System.Collections.Generic.IDictionary<string, string> Find(string language)
        {
            var query = from p in _db.Ressources
                         where p.RessourceLanguage == language
                         select p;

            Dictionary<string, string> ressources = new Dictionary<string, string>();
            foreach(var item in query)
            {
                ressources.Add(item.RessourceKey,item.RessourceValue);
            }
            return ressources;
        }

        #endregion

        #region ITenantModel Members

        private TenantContext _context;
        public BA.MultiMvc.Framework.Core.TenantContext Context
        {
            get { return _context; }
            set 
            { 
                _context = value;
                _db = new DBDataContext(_context.ConnectionString);
            }
        }

        #endregion
    }
}