using System.Collections.Generic;
using BA.MultiMVC.Framework.Ressources;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;
using System.Linq;

namespace BA.MultiTenantMVC.Sample.Models.Infrastructure
{
    public class RessourceRepository :  IRessourceRepository
    {
        DBDataContext _db;

        public RessourceRepository()
        {}

        public RessourceRepository(DBDataContext db) // Contructor used by tests!
        {
            _db = db;
        }

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

        #region IRepository Members

        private string _connectionString;
        public string ConnectionString 
        {
            get { return _connectionString; }
            set
            {
               _connectionString = value;
               _db = new DBDataContext(_connectionString);
            }
        }

        #endregion
    }
}