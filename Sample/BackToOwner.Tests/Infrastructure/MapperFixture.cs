using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Test.Stubs;
using BackToOwner.Golf.Web.Test.UnitTests;
using BackToOwner.Golf.Web.ViewModels;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackToOwner.Golf.Web.Test
{
    [TestClass]
    public class GivenDefaultMapper : GivenTenantContextAndServiceConfigured 
    {
        protected DefaultMapperService MapperService;

        public override void Given()
        {
            MapperService = new DefaultMapperService();
        }
    }

    [TestClass]
    public class GivenActivateIndexRequest:GivenDefaultMapper
    {
        protected ActivateIndexRequest ContactRequest;

        public override void Given()
        {
            base.Given();
            TenantResources.SetTenantResourceProvider(new StubResourceProvider());
            ContactRequest = new ActivateIndexRequest
                                 {
                                     Email = "someEmail@fomain.com",
                                     ConfirmEmail = "someEmail@fomain.com",
                                     Email2 = "someOtherEmail@fomain.com",
                                     Gender = Gender.Male,
                                     FirstName = "Geoffrey",
                                     Password = "somepassword",
                                     ConfirmPassword = "somepassword"
                                 };
        }
    }

    [TestClass]
    public class WhenMapActivateIndexRequestToOwner:GivenActivateIndexRequest
    {
        protected Owner Owner;

        public override void When()
        {
            base.When();
            Owner = DomainStubFactory.CreateOwner();
            Owner = MapperService.MapToOwner(Owner, ContactRequest);
        }

        [TestMethod]
        public void RequestShouldBeMappedToOwner()
        {
            Assert.AreEqual(ContactRequest.Email, Owner.EmailAddresses[0]);
            Assert.AreEqual(ContactRequest.Email2, Owner.EmailAddresses[1]);
            Assert.AreEqual(ContactRequest.ConfirmEmail, Owner.EmailAddresses[0]);
            Assert.AreEqual(ContactRequest.FirstName,Owner.FirstName);
            Assert.AreEqual(ContactRequest.LastName,Owner.LastName);
            Assert.AreEqual(ContactRequest.LastName, Owner.LastName);
        }
    }

    [TestClass]
    public class GivenActivateMobileRequest:GivenDefaultMapper
    {
        protected ActivateMobileRequest Request;

        public override void Given()
        {
            base.Given();
            Request = new ActivateMobileRequest
                          {
                              AcceptTerms = true,
                              CountryCode = "32",
                              PhoneNumber = "495204340",
                              CountryCode2 = "41",
                              PhoneNumber2 = "900890990"
                          };
        }
    }

    [TestClass]
    public class WhenMapActivateMobileRequestToOwner : GivenActivateMobileRequest
    {
        protected Owner Owner;

        public override void When()
        {
            base.When();
            Owner = DomainStubFactory.CreateOwner();
            Owner = MapperService.MapToOwner(Owner, Request);
        }

        [TestMethod]
        public void MobileRequestShouldBeMappedToOwner()
        {
            Assert.AreEqual(2, Owner.Mobiles.Count);
            Assert.AreEqual("32495204340", Owner.Mobiles[0]);
            Assert.AreEqual("41900890990", Owner.Mobiles[1]);
        }
    }

    public class GivenDeclareIndexRequest : GivenDefaultMapper
    {
        protected DeclareIndexRequest Request;
        public override void Given()
        {
            base.Given();
            Request = new DeclareIndexRequest
                          {
                              CountryCode = "32",
                              PhoneNumber = "0495204340",
                              Email = "gvd8@hotmail.com",
                              FirstName = "Geoffrey",
                              LastName = "Vandiest"
                          };

        }
    }

    [TestClass]
    public class WhenMapDeclaration : GivenDeclareIndexRequest
    {
        protected Declaration Result;
        public override void When()
        {
            Result = MapperService.MapToDeclaration(Request, new Badge {Nbr = "1265-1265-1265"}, "fr");
        }

        [TestMethod]
        public void ShouldMapToDeclaration()
        {
            Assert.AreEqual("32495204340",Result.PhoneNumber);
        }
    }

    [TestClass]
    public class GivenDeclaration:GivenDefaultMapper
    {
        protected Declaration Declaration;
        protected DeclareSendMessageRequest ExpectedResult;
        protected DeclareSendMessageRequest Result;

        public override void Given()
        {
            base.Given();
            this.Declaration = DomainStubFactory.CreateDeclaration(new Badge { Nbr = "1265-1265-1265" });
   
            ExpectedResult = DomainStubFactory.CreateDeclareSendMessageRequest(this.Declaration);
        }

        public override void When()
        {
            Result = MapperService.MapToDeclareSendMessageRequest(Declaration);
        }

        [TestMethod]
        public void MapToDeclarationSendMessageRequest()
        {
            
            Assert.AreEqual(ExpectedResult.Declaration.Message,Result.Declaration.Message);
            Assert.AreEqual(ExpectedResult.Declaration.PhoneNumber, Result.Declaration.PhoneNumber);
            Assert.AreEqual(ExpectedResult.Declaration.RetrivedBadge.Nbr, Result.Declaration.RetrivedBadge.Nbr);
            Assert.AreEqual(ExpectedResult.Declaration.EmailAddress, Result.Declaration.EmailAddress);
        }
    }
}
