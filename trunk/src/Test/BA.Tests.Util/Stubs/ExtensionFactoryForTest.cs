using System;
using System.Web.Mvc;
using System.Web.Routing;
using BA.MultiMVC.Core;


namespace BA.MultiMVC.Test.Util.Stubs
{

    public class ExtensionControllerFactoryForTest : ExtensionControllerFactory
    {
        #region properties
        string _tenantKey;
        public string TenantKey
        {
            get
            {
                return TenantKey;
            }
            set
            {
                _tenantKey = value;
                setRequestContext(_tenantKey);
            }
        }
        #endregion

        #region methods
        private void setRequestContext(string tenantKey)
        {
            var routreData = new RouteData();
            routreData.Values.Add("tenantKey", tenantKey);
            routreData.Values.Add("language", "fr");
            routreData.Values.Add("controller", "HomeController");
            RequestContext = new RequestContext(
                MvcMockHelpers.FakeHttpContext(),
                routreData);
        }

        public IController GetControllerInstanceInvoker(Type type)
        {
            return GetControllerInstance(type);
        }

        
        #endregion Methods
    }
}