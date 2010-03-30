using System.Collections.Generic;

namespace BA.MultiMvc.Framework.Core
{
    public class BaseViewModel
    {

        public BaseViewModel(TenantContext context)
        {
            _context = context;
            _resources = context.Resources;
        }

        protected TenantContext _context;
        public TenantContext Context { get { return _context; } }

        protected IDictionary<string, string> _resources;
        public IDictionary<string,string> Resources { get{ return _resources;} }
    }
}
