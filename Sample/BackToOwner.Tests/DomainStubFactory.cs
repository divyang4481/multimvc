using System;
using System.Collections.Generic;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.ViewModels;
using BackToOwner.Web.Setup;

namespace BackToOwner.Golf.Web.Test
{
    public static class DomainStubFactory
    {
        public static Owner CreateOwner()
        {
            var mobiles = new Dictionary<int, string>
                              {
                                  {0, "0495204340"},
                                  {1, "0496564340"}
                              };
            
            var emailAdresse = new Dictionary<int,string>()
                                   {
                                       {0, "test@domain.com"},
                                       {1, "test2@domain.com"}
                                   };

            
            var ret = new Owner
                       {
                           FirstName = "Geoffrey",
                           Language = Language.fr,
                           Gender = Gender.Male,
                           PasswordHash="kljkljkljkljk",
                           PasswordSalt = "lmklmkm",
                           LastName = "Vandiest",
                           RegistrationDate = DateTime.Now
                         };
            ret.EmailAddresses = new Dictionary<int,string>{{0,"test@domain.com"},{1,"test2@domain.com"}};
            ret.Mobiles = mobiles;
            ret.AddBadge(new Badge {Nbr = "ABC-RTY-RTY"});
            ret.AddBadge(new Badge {Nbr = "ABC-KLM-POM" });
            return ret;
        }

        public static Declaration CreateDeclaration(Badge badge)
        {
            return new Declaration
            {
                EmailAddress = "gvd8@hotmail.com",
                FirstName = "Gregory",
                Language = Language.fr,
                LastName = "Vandiest",
                Message = "Hello wordl!",
                PhoneNumber = "32495204340",
                RetrivedBadge = badge
            };
        }

        public static DeclareSendMessageRequest CreateDeclareSendMessageRequest(Declaration declaration)
        {
            

            return new DeclareSendMessageRequest
            {
                Declaration = DomainStubFactory.CreateDeclaration(declaration.RetrivedBadge)
            };
        }

        public static Dictionary<string, string> CreateResources()
        {
            var resources = new Dictionary<string, string>();
            foreach (var resource in DefaultResourceCreation.CreateResources())
            {
                try
                {
                    if (resource.Language == "en") resources.Add(resource.Label, resource.Value);
                }
                catch (System.ArgumentException)
                {
                }
            }
            return resources;
        }
    }
}
