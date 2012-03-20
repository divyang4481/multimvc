using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Test.Stubs
{
    public class StubTenantContextProvider:ITenantContextProvider
    {
        #region ITenantContextProvider Members

        public string TenantKey
        {
            get { return "Default"; }
        }

        public string Language
        {
            get { return "fr"; }
        }

        #endregion
    }
}
