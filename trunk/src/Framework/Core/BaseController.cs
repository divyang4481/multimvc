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

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (ViewData.Model == null)
                ViewData.Model = new BaseViewModel();

            var vM = ViewData.Model as BaseViewModel;
            if (vM != null)
                vM.Resources = Ressources;

            base.OnActionExecuted(filterContext);
        }



        #endregion Methods
    }
}