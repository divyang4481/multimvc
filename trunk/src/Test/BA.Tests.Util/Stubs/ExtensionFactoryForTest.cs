using System;
using System.Web.Mvc;
using System.Web.Routing;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.Core.MultiMvc.Test.Util;


namespace BA.MultiMvc.Test.Util.Stubs
{
    public class ExtensionControllerFactoryForTest : ExtensionControllerFactory
    {
        #region properties
        string _tenantKey;
        public string TenantKey
        {
            get
            {
                return _tenantKey;
            }
            set
            {
                _tenantKey = value;
            }
        }
        #endregion

        #region methods
        private RequestContext GetRequestContext(string tenantKey)
        {
            var routreData = new RouteData();
            routreData.Values.Add("tenantKey", tenantKey);
            routreData.Values.Add("language", "fr");
            routreData.Values.Add("controller", "HomeController");
            return new RequestContext(
                MvcMockHelpers.FakeHttpContext(),
                routreData);
        }

        public IController GetControllerInstanceInvoker(Type type)
        {
            return GetControllerInstance(GetRequestContext(this.TenantKey),type);
        }

        
        #endregion Methods
    }
}