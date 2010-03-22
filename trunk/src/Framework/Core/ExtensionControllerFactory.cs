using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BA.MultiMvc.Framework.Helpers;
using StructureMap;
using System.Web.Routing;
using BA.MultiMvc.Framework.Ressources;


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
                var tenantResources = GetTenantResources(tenantContext);
                return GetControllerInstance(tenantContext, tenantResources ,controllerType);

            }
            return null;
        }

        protected virtual TenantContext GetTenantContext(RequestContext request)
        {
            var tenantKey = request.RouteData.GetTenantKey();
            var language = request.RouteData.GetLanguage();
            return new TenantContext(tenantKey, language);
        }

        protected virtual IDictionary<string,string> GetTenantResources(TenantContext context)
        {
            var factory = new TenantFactory(context);
            var resourceProvider = factory.Create<IRessourceProviderService>();
            return resourceProvider.GetRessources();
        }
        

        protected virtual IController GetControllerInstance(TenantContext context,IDictionary<string,string> resources, Type controllerType)
        {
            if (controllerType==null)
                return null;

            var controller = CreateControllerExtension(context.TenantKey, controllerType)
                             ?? base.GetControllerInstance(controllerType) as BaseController;

            if (controller != null)
            {
                controller.Context = context;
                controller.Resources = resources;
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