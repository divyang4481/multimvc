using System;
using System.Web.Mvc;
using BA.MultiMvc.Framework.Helpers;
using StructureMap;
using System.Web.Routing;


namespace BA.MultiMvc.Framework.Core
{
    public class ExtensionControllerFactory : StructureMapControllerFactory
    {
        #region Methods

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (RequestContext != null)
            {
                var tenantContext = GetTenantContext(RequestContext);
                return GetControllerInstance(tenantContext, controllerType);

            }
            return null;
        }

        protected virtual TenantContext GetTenantContext(RequestContext request)
        {
            var tenantKey = request.RouteData.GetTenantKey();
            var language = request.RouteData.GetLanguage();
            return  new TenantContext(tenantKey, language);
        }

        

        protected virtual IController GetControllerInstance(TenantContext context, Type controllerType)
        {
            if (controllerType==null)
                return null;

            var controller = CreateControllerExtension(context.TenantKey, controllerType)
                             ?? base.GetControllerInstance(controllerType) as BaseController;

            if (controller != null)
            {
                controller.Init(context);
                return controller;
            }

            return null;
        }
     
        private static BaseController CreateControllerExtension(string tenantKey, Type controllerType)
        {
            if (controllerType == null)
                return null;

            string controllerName = tenantKey + controllerType.Name.Replace("Controller", "");

            BaseController controller;
            try
            {
                controller = ObjectFactory.GetNamedInstance(typeof(BaseController), controllerName) as BaseController;
            }
            catch (StructureMapException)
            {
                return null;
            }

            return controller;
        }

       

        #endregion Methods
    }
}