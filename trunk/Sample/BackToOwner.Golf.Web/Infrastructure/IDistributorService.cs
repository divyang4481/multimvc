using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface IDistributorService:ITenantModel
    {
        void SendActivationConfirmation(Badge badge);

        void Send(Declaration Declaration);
        void SendPassword(Owner owner, string newPassword);
    }
}
