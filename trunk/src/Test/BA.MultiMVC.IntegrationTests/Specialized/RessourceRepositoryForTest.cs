using BA.MultiTenantMVC.Sample.Models.Infrastructure;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;

namespace BA.MultiMvc.Framework.IntegrationTests.Specialized
{
    public class RessourceRepositoryForTest:RessourceRepository
    {
        public RessourceRepositoryForTest(DBDataContext db) // Contructor used by tests!
        {
            _db = db;
        }
    }
}