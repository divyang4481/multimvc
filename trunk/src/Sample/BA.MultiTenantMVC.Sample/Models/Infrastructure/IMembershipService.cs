using BA.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Core;

namespace BA.MultiMVC.Sample.Models.Infrastructure
{
    public interface IMembershipService:IService
    {
        IUserRepository UserRepository { get; set; } 
        void Register(User user);
        bool Login(string userName, string password);
    }
}
