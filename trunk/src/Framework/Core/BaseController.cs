using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using BA.MultiMVC.Framework.Helpers;
using Castle.Components.Validator;

namespace BA.MultiMVC.Framework.Core
{
    public class BaseController : Controller
    {
        #region Properties

        public TenantContext TenantContext { get; set; }
        public IDictionary<string, string> Ressources { get; set; }
        #endregion Properties

        #region Methods

        protected void AddModelErrorsToForm(NameValueCollection formCollection, ErrorSummary errorsummary)
        {
            ModelState.AddModelErrors(errorsummary, Ressources, formCollection);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewData["language"] = TenantContext. Language;
            filterContext.Controller.ViewData["tenantKey"] = TenantContext.TenantKey;
            filterContext.Controller.ViewData["ressources"] = Ressources;

            base.OnActionExecuting(filterContext);
        }

        #endregion Methods
    }
}