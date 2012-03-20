using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface ISmsService:ITenantModel
    {
        void Send(string number, string text);
    }
}