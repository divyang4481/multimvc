using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure
{
    public interface IMembershipService:ITenantModel
    {
        IUserRepository UserRepository { get; set; } 
        void Register(User user);
        bool Login(string userName, string password);
    }
}
