using BA.MultiMvc.Sample.Models.Infrastructure.Linq;
using BA.MultiMvc.Sample.Models.Infrastructure;

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