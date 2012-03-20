using System;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;

namespace BackToOwner.Golf.Web.Application
{
    public class ApplicationFacade : ITenantModel
    {
        protected readonly ISessionService SessionService;
        protected readonly IDistributorService DistributorService;
        protected readonly IRepository<Badge, string> BadgeRepository;
        protected readonly IRepository<Declaration> DeclarationRepository;
        protected readonly ISecurityService SecurityService;
        protected readonly IAuthenticationService AuthenticationService;
        protected readonly IRepository<Owner> OwnerRepository;
        protected readonly IMapperService MapperService;

        public ApplicationFacade(
            ISessionService sessionService,
            IDistributorService distributorService,
            IRepository<Badge, string> badgeRepository,
            IRepository<Declaration> declarationRepository,
            ISecurityService securityService,
            IAuthenticationService authenticationService,
            IRepository<Owner> ownerRepository,
            IMapperService mapperService)
        {
            this.SessionService = sessionService;
            this.DistributorService = distributorService;
            this.BadgeRepository = badgeRepository;
            this.SecurityService = securityService;
            this.DeclarationRepository = declarationRepository;
            this.AuthenticationService = authenticationService;
            this.OwnerRepository = ownerRepository;
            this.MapperService = mapperService;
        }

        public Badge CurrentBadge
        {
            get
            {
                var badgeNbr = SessionService["badgeNbr"] as string;
                if (badgeNbr == null)
                {
                    return null;
                }

                var badge = BadgeRepository.GetBy(n => n.Nbr == badgeNbr);

                return badge;
            }
        }

        public Owner OwnerToBeActivate
        {
            get
            {
                return this.SessionService["owner"] as Owner;
            }
        }

        public void CheckCurrentBadgeIsForDeclaration()
        {
            if (!this.CurrentBadge.IsActive)
            {
                throw new InvalidOperationException("Badge is not activated!");
            }
        }

        private bool IsBadgeNbrValidAndNotRegistred(string badgeNbr)
        {
            return BadgeRepository.GetBy(n => n.Nbr == Badge.NormailzeLabelCode(badgeNbr)) == null;
        }

        public void SetCurrentBadge(string badgeNbr)
        {
            string ip = this.SessionService.Ip;
            if (this.SecurityService.IsRequestorBlackListed(ip))
            {
                throw new InvalidOperationException("IP is locked!");
            }

            if (IsBadgeNbrValidAndNotRegistred(badgeNbr))
            {
                this.SecurityService.AuditFailure(ip);
                throw new InvalidOperationException("BadgeNbr is not valid");
            }
            this.SecurityService.AuditSuccess(ip);
            this.SessionService["badgeNbr"] = Badge.NormailzeLabelCode(badgeNbr);
        }

        public void HashOwnerPassword(ActivateIndexRequest request)
        {
            if (this.CurrentBadge == null)
            {
                throw new InvalidOperationException("Badge Nbr was not retrieved from Session!");
            }

            var owner = MapperService.MapToOwner(new Owner(), request);
            string salt;
            owner.PasswordHash = this.SecurityService.Hash(request.Password, out salt);
            owner.PasswordSalt = salt;
            SessionService["owner"] = owner;
        }

        public void RegisterOwner(ActivateMobileRequest request)
        {
            var owner = MapperService.MapToOwner(this.OwnerToBeActivate, request);
            var badge = this.BadgeRepository.GetBy(n => n.Nbr == this.CurrentBadge.Nbr);

            owner.AddBadge(badge);

            this.BadgeRepository.Save(badge.Owner);
            this.BadgeRepository.Commit();

            DistributorService.SendActivationConfirmation(badge);

        }

        public void AddNewOwnerToSession(Language language)
        {
            var owner = new Owner(language, this.CurrentBadge);
            SessionService["owner"] = owner;
        }

        public Declaration CurrentDeclaration
        {
            get
            {
                Guid declarationId = new Guid(SessionService["declarationId"].ToString());
                if (declarationId == null)
                {
                    throw new InvalidOperationException("declarationId was not found in Session");
                }

                var declaration = this.DeclarationRepository.GetById(declarationId);
                if (declaration == null)
                {
                    throw new InvalidOperationException("declarationId was not retrieved from DeclarationRepository!");
                }
                return declaration;
            }
        }

      

       

       

        

        

        public DeclareSendMessageRequest GetCurrentDeclareSendMessageRequest()
        {
            return this.MapperService.MapToDeclareSendMessageRequest(this.CurrentDeclaration);
        }
   
        public Owner CurrentSignedInOwner
        {
            get
            {
                if (this.SecurityService.Identity == null)
                {
                    this.SecurityService.SignOut();
                    throw new InvalidOperationException("Identity was not found, owner should first login!");
                }

                var owner = this.OwnerRepository.GetById(new Guid(this.SecurityService.Identity));

                if (owner == null)
                {
                    this.SecurityService.SignOut();
                    throw new InvalidOperationException("Identity was incorect, probably owner identity is not valid anymore, owner should first login!");
                }

                return owner;
            }
        }

        public EditOwnerRequest GetEditProfileRequestForCurrentSignedInOwner()
        {
            return this.MapperService.MapToEditProfileRequest(this.CurrentSignedInOwner);
        }

        public EditOwnerRequest SaveOwnerChanges(EditOwnerRequest model)
        {
            var owner = this.CurrentSignedInOwner;
            owner = this.MapperService.MapToOwner(owner, model);
            this.OwnerRepository.Save(owner);
            this.OwnerRepository.Commit();

            model.ConfirmationMessage = TenantResources.Values["edit_owner_confirm"];
            return model;
        }

        public void AddBadgeToOwner(string newBadgeNbr)
        {
            var badge = this.BadgeRepository.GetBy(n => n.Nbr == Badge.NormailzeLabelCode(newBadgeNbr));
            this.CurrentSignedInOwner.AddBadge(badge);
            this.OwnerRepository.Save(this.CurrentSignedInOwner);
            this.OwnerRepository.Commit();
        }

        public void RemoveBadge(string badgeNbr)
        {
            var badge = this.BadgeRepository.GetBy(n => n.Nbr == badgeNbr);
            this.CurrentSignedInOwner.RemoveBadge(badge);
            this.OwnerRepository.Save(this.CurrentSignedInOwner);
            this.OwnerRepository.Commit();

        }

        public void DeleteAccount()
        {
            this.CurrentSignedInOwner.RemoveAllBadges();
            this.OwnerRepository.Delete(this.CurrentSignedInOwner);
            this.OwnerRepository.Commit();
            this.SecurityService.SignOut();
        }

        public void ChangePassword(ChangePasswordRequest model)
        {
            Owner owner = this.CurrentSignedInOwner;
            string oldHasedPasword = this.SecurityService.Hash(model.OldPassword, owner.PasswordSalt);

            if (oldHasedPasword != owner.PasswordHash)
            {
                model.ConfirmMessage = TenantResources.Values["err_wrong_oldpassword"];
                return;
            }

            string newSalt;
            string newHashedPassword = this.SecurityService.Hash(model.NewPassword, out newSalt);

            owner.PasswordHash = newHashedPassword;
            owner.PasswordSalt = newSalt;
            this.OwnerRepository.Save(owner);
            this.OwnerRepository.Commit();
            model.ConfirmMessage = TenantResources.Values["password_changed"];

        }
    }
}