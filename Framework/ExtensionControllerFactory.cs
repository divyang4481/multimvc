using System;
using System.Web.Mvc;
using StructureMap;


namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Controller Factory that should be registred to enable multi tenancy controllers.
    /// It get controller instances for a specific Tenant.  If it don't find one it returns the default Controller.
    /// </summary>
    public class ExtensionControllerFactory : StructureMapControllerFactory
    {
        #region Methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType==null||requestContext==null)
                return null;

            var controller = CreateControllerExtension(TenantContext.TenantKey, controllerType)
                             ?? base.GetControllerInstance(requestContext , controllerType) as Controller;

            return controller;
        }
     
        private static Controller CreateControllerExtension(string tenantKey, Type controllerType)
        {
            if (controllerType == null)
                return null;

            string controllerName = tenantKey + controllerType.Name.Replace("Controller", "");
            
            Controller controller;
            try
            {
                controller = ObjectFactory.GetNamedInstance(typeof(Controller), controllerName) as Controller;
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