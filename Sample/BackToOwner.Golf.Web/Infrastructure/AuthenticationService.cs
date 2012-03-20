using System;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface IAuthenticationService:ITenantModel
    {
        bool Authenticate(string badgeNbr, string password, out Guid ownerId);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IRepository<Badge, string> repository;
        private ISecurityService securityService;

        public AuthenticationService(IRepository<Badge, string> repository, ISecurityService securityService)
        {
            this.repository = repository;
            this.securityService = securityService;
        }

        public bool Authenticate(string badgeNbr, string password, out Guid ownerId)
        {
            ownerId = Guid.Empty;

            var badge = repository.GetBy(n=>n.Nbr == badgeNbr);

            if (badge == null || badge.Owner == null) return false;

            string hashedPassword = this.securityService.Hash(password, badge.Owner.PasswordSalt);

            if (badge.Owner.PasswordHash == hashedPassword)
            {
                ownerId = badge.Owner.Id;
                return true;
            }

            return false;

        }
    }
}
