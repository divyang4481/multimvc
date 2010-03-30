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

        private TenantContext _context;
        public TenantContext Context { get { return _context; } }

        private IDictionary<string, string> _resources;
        public IDictionary<string,string> Resources { get{ return _resources;} }
    }
}
