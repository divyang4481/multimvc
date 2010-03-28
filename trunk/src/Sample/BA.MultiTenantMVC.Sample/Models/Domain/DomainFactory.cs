using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain
{
    public class DomainFactory:TenantFactory
    {
    
        public DomainFactory(TenantContext context)
            : base(context )
        { }

    }
}
