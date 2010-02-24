using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiTenantMVC.Sample.Models.Infrastructure;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;

namespace BA.MultiMVC.IntegrationTests.Spesialised
{
    public class RessourceRepositoryForTest:RessourceRepository
    {
         public RessourceRepositoryForTest(DBDataContext db) // Contructor used by tests!
        {
            _db = db;
        }
    }
}
