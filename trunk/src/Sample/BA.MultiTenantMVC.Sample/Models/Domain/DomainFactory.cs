using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain
{
    public class DomainFactory:TenantFactory
    {
    
        public DomainFactory(TenantContext context)
            : base(context )
        { }

    }
}
