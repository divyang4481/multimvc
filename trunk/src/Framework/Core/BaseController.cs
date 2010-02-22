using System.Collections.Specialized;
using System.Web.Mvc;
using Castle.Components.Validator;
using BA.MultiMVC.Helpers;
using BA.MVC.MultiTenant.Core;

namespace BA.MultiMVC.Core
{
    public class BaseController : Controller
    {
        #region Properties

        public TenantContext TenantContext { get; set; }

        #endregion Properties

        #region Methods

        protected void AddModelErrorsToForm(NameValueCollection formCollection, ErrorSummary errorsummary)
        {
            ModelState.AddModelErrors(errorsummary, TenantContext.Ressources, formCollection);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewData["language"] = TenantContext. Language;
            filterContext.Controller.ViewData["tenantKey"] = TenantContext.TenantKey;
            filterContext.Controller.ViewData["ressources"] = TenantContext.Ressources;

            base.OnActionExecuting(filterContext);
        }

        #endregion Methods
    }
}