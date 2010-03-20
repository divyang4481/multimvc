using System.Collections.Generic;

namespace BA.MultiMVC.Framework.Core
{
    public class BaseViewModel
    {
        public TenantContext Context { get; set; }
        public IDictionary<string,string> Resources { get; set; }
    }
}
