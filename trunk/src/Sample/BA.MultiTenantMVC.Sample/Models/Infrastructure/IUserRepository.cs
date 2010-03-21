using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Infrastructure
{
    public interface IUserRepository:ITenantModel
    {
        void Save(User user);
        void Load(string userName);
    }
}
