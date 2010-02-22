using BA.MultiMVC.Core;
using BA.MVC.MultiTenant.Core;

namespace BA.MultiMVC.Sample.Models.Domain
{
    public class DomainFactory:TenantFactory
    {
    
        public DomainFactory(TenantContext context)
            : base(context )
        { }

    }
}
