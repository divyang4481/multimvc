using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Extensions.Contoso.Infrastructure
{
    public class ContosoMembershipService:MembershipService  
    {
        public ContosoMembershipService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
