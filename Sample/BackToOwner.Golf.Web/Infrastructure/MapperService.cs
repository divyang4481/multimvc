using System;
using System.Collections.Generic;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface IMapperService : ITenantModel
    {
        Owner MapToOwner(Owner to, ActivateIndexRequest request);

        Owner MapToOwner(Owner to, ActivateMobileRequest request);

        Declaration MapToDeclaration(DeclareIndexRequest request, Badge badge, string language);

        DeclareSendMessageRequest MapToDeclareSendMessageRequest(Declaration declaration);

        EditOwnerRequest MapToEditProfileRequest(Owner owner);

        Owner MapToOwner(Owner owner, EditOwnerRequest model);
    }

    public class DefaultMapperService : IMapperService
    {

        public Owner MapToOwner(Owner to, ActivateIndexRequest request)
        {
            to.EmailAddresses[0] = request.Email;
            if (!String.IsNullOrEmpty(request.Email2))
            {
                to.EmailAddresses[1] = request.Email2;
            }
            to.FirstName = request.FirstName;
            to.LastName = request.LastName;
            to.Gender = request.Gender;
            return to;
        }

        public Owner MapToOwner(Owner owner, ActivateMobileRequest request)
        {
            var mobiles = new Dictionary<int, string>();
            mobiles.Add(0, request.CountryCode + RemoveLeading0(request.PhoneNumber));
            if (!String.IsNullOrEmpty(request.CountryCode2) && !String.IsNullOrEmpty(request.PhoneNumber2))
            {
                mobiles.Add(1, request.CountryCode2 + RemoveLeading0(request.PhoneNumber2));
            }
            owner.Mobiles = mobiles;
            return owner;
        }

        public Declaration MapToDeclaration(DeclareIndexRequest request, Badge badge, string language)
        {
            Language mappedLanguage;
            if (!Language.TryParse(language, true, out mappedLanguage))
            {
                throw new InvalidOperationException(language + " is an invalid language!");
            }

            var declaration = new Declaration
                                  {
                                      EmailAddress = request.Email,
                                      FirstName = request.FirstName,
                                      LastName = request.LastName,
                                      Language = mappedLanguage,
                                      PhoneNumber =
                                          request.CountryCode +
                                          RemoveLeading0(request.PhoneNumber.Trim("_".ToCharArray())),
                                      RetrivedBadge = badge,
                                  };

            declaration.RetrivedBadge.Owner = badge.Owner;
                //needed otherwize we get a lazy load exception when we retrieve the object from session
            return declaration;
        }

        public DeclareSendMessageRequest MapToDeclareSendMessageRequest(Declaration declaration)
        {
            DeclareSendMessageRequest to = new DeclareSendMessageRequest
                                               {
                                                   Declaration = declaration
                                               };
            return to;
        }

        public EditOwnerRequest MapToEditProfileRequest(Owner owner)
        {
            var to = new EditOwnerRequest();

            if (owner.Mobiles.Count > 0)
            {
                to.CountryCode = owner.Mobiles[0].Substring(0, 2);
                to.PhoneNumber = owner.Mobiles[0].Substring(2, owner.Mobiles[0].Length - 2);
            }
            if (owner.Mobiles.Count > 1)
            {
                to.CountryCode2 = owner.Mobiles[1].Substring(0, 2);
                to.PhoneNumber2 = owner.Mobiles[1].Substring(2, owner.Mobiles[1].Length - 2);
            }

            if (owner.EmailAddresses.Count > 0) to.Email = owner.EmailAddresses[0];
            if (owner.EmailAddresses.Count > 1) to.Email2 = owner.EmailAddresses[1];
            to.FirstName = owner.FirstName;
            to.LastName = owner.LastName;
            to.Gender = owner.Gender;
            return to;
        }

        private static string RemoveLeading0(string str)
        {
            if (str.Substring(0, 1) == "0")
            {
                str = str.Remove(0, 1);
            }

            return str;
        }

        public Owner MapToOwner(Owner owner, EditOwnerRequest model)
        {

            if (!String.IsNullOrEmpty(model.Email)) owner.EmailAddresses[0] = model.Email;
            if (!String.IsNullOrEmpty(model.Email2)) owner.EmailAddresses[1] = model.Email2;
            if (!String.IsNullOrEmpty(model.PhoneNumber)) owner.Mobiles[0] = model.CountryCode + model.PhoneNumber.TrimStart("0".ToCharArray());
            if (!String.IsNullOrEmpty(model.PhoneNumber2)) owner.Mobiles[1] = model.CountryCode2 + model.PhoneNumber2.TrimStart("0".ToCharArray());

            if (!String.IsNullOrEmpty(owner.FirstName))owner.FirstName = model.FirstName;
            if (!String.IsNullOrEmpty(owner.LastName)) owner.LastName = model.LastName;
            
            owner.Gender = model.Gender;

            return owner;
        }
    }

}