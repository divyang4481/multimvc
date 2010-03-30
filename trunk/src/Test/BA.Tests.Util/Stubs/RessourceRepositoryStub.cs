using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;

namespace BA.MultiMvc.Test.Util.Stubs
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

        public TenantContext Context
        {
            get; set;
        }

        #endregion
    }
}