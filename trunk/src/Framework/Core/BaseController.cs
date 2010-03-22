using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;
using BA.MultiMvc.Framework.Helpers;
using Castle.Components.Validator;

namespace BA.MultiMvc.Framework.Core
{
    public class BaseController : Controller
    {
        #region Properties

        public TenantContext Context { get; set; }
        public IDictionary<string, string> Resources { get; set; }
        #endregion Properties

        #region Methods

        protected void AddModelErrorsToForm(NameValueCollection formCollection, ErrorSummary errorSummary)
        {
            ModelState.AddModelErrors(errorSummary, Resources, formCollection); 
            
            
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (ViewData.Model == null)
                ViewData.Model = new BaseViewModel();

            var vM = ViewData.Model as BaseViewModel;
            if (vM != null)
            {
                vM.Resources = Resources;
                vM.Context = Context;
            }

            base.OnActionExecuted(filterContext);
        }



        #endregion Methods
    }
}