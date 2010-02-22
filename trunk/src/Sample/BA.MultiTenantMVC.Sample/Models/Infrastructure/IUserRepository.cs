using BA.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Core;

namespace BA.MultiMVC.Sample.Models.Infrastructure
{
    public interface IUserRepository:IRepository
    {
        void Save(User user);
        void Load(string userName);
    }
}
