using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;


namespace BA.MultiMvc.Sample.Models.Infrastructure
{
    public interface IUserRepository:ITenantModel
    {
        void Save(User user);
        void Load(string userName);
    }
}