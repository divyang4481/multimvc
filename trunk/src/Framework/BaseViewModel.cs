using System.Collections.Generic;

namespace BA.MultiMvc.Framework
{
    public class BaseViewModel
    {

        public BaseViewModel(TenantContext context, IDictionary<string,string> resources)
        {
            _context = context;
            this._resources = resources;
        }

        private TenantContext _context;
        public TenantContext Context { get { return _context; } }

        private IDictionary<string, string> _resources;
        public IDictionary<string,string> Resources { get{ return _resources;} }
    }
}