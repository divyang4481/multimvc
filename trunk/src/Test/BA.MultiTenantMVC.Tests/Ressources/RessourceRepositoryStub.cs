using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMVC.Framework.Ressources;

namespace BA.MultiTenantMVC.Framework.UnitTests.Ressources
{
    public class RessourceRepositoryStub:IRessourceRepository
    {
        #region IRessourceRepository Members

        public IDictionary<string, string> Find(string language)
        {
            IDictionary<string, string> fakeDico = new Dictionary<string, string>();
            return fakeDico;
        }

        #endregion

        #region ITenantModel Members

        public BA.MultiMVC.Framework.Core.TenantContext Context
        {
            get; set;
        }

        #endregion
    }
}
