using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Compilation;
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
            get
            {
                if (_resources == null)
                {
                    var factory = new TenantFactory(this.Context);
                    var resourceProvider = factory.Create<IResourceProvider>();
                    _resources = (resourceProvider != null) ? resourceProvider.GetResources() : null;
                }
                return _resources;
            }
        }
        #endregion Properties

        #region Methods
        internal void Init(TenantContext context)
        {
            _context = context;
        }

    
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (ViewData.Model == null)
                ViewData.Model = new BaseViewModel(Context, Resources);

            base.OnActionExecuted(filterContext);
        }



        #endregion Methods
    }
}