using BA.MultiMVC.Sample.Models.Infrastructure;

namespace BA.MultiMVC.Sample.Extensions.Contoso.Infrastructure
{
    public class ContosoMembershipService:MembershipService  
    {
        public ContosoMembershipService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
