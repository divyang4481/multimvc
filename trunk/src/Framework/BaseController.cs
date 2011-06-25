using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Mvc;

namespace BA.MultiMvc.Framework
{
    public abstract class BaseController : Controller
    {
        private IDictionary<string, string> _resources;
        private TenantContext _context;
        
        #region Properties
        public TenantContext Context
        {
            get { return _context; }
        }
        
        public IDictionary<string, string> Resources
        {
            get { return _resources; }
        }
        #endregion Properties

        #region Methods
        internal void Init(TenantContext context)
        {
            _resources =context.Resources;
            _context = context;
        }

    
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (ViewData.Model == null)
                ViewData.Model = new BaseViewModel(Context);

            base.OnActionExecuted(filterContext);
        }



        #endregion Methods
    }
}