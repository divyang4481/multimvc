using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure
{
    public interface IUserRepository:IRepository
    {
        void Save(User user);
        void Load(string userName);
    }
}
