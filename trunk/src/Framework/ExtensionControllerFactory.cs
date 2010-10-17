using System;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;


namespace BA.MultiMvc.Framework
{
    public class ExtensionControllerFactory : StructureMapControllerFactory
    {
        #region Methods
        
        protected virtual TenantContext GetTenantContext(RequestContext request)
        {
            var tenantKey = request.RouteData.GetTenantKey();
            var language = request.RouteData.GetLanguage();
            return  new TenantContext(tenantKey, language);
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (requestContext != null)
            {
                var tenantContext = GetTenantContext(requestContext);
                return GetControllerInstance(requestContext,tenantContext, controllerType);

            }
            return null;
        }

        protected virtual IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, TenantContext context, Type controllerType)
        {
            if (controllerType==null)
                return null;

            var controller = CreateControllerExtension(context.TenantKey, controllerType)
                             ?? base.GetControllerInstance(requestContext , controllerType) as BaseController;

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