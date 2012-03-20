using System;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface ISecurityService:ITenantModel
    {
       string Hash(string password, out string passwordSalt);
       string Hash(string password, string passwordSalt);
       void SetAuthenticationCookie(string userId, bool remember);
       string GenerateRandomPaswword();
       string Identity { get; }

       void SignOut();

       bool IsRequestorBlackListed(string requestorIp);

       void AuditFailure(string ip);

       void AuditSuccess(string ip);
    }
}
