using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure
{
    public interface IMembershipService:ITenantModel
    {
        IUserRepository UserRepository { get; set; } 
        void Register(User user);
        bool Login(string userName, string password);
    }
}
