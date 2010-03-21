using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Domain
{
    public class DomainFactory:TenantFactory
    {
    
        public DomainFactory(TenantContext context)
            : base(context )
        { }

    }
}
