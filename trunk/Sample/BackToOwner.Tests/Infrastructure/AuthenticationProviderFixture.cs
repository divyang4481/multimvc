using System;
using System.Web.Security;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Tests.Infrastructure
{
    [TestClass]
    public class AuthenticationProviderFixture:Specification
    {
        protected IRepository<Badge,string> OwnerRepository;
        protected ISecurityService SecurityServiceMocked;
        protected Owner OwnerThatLogsIn;
        protected AuthenticationService Subject;
        protected string Password;
        protected bool Result;
        protected Guid OwnerId;
        
        public override void Given()
        {
            this.OwnerThatLogsIn = DomainStubFactory.CreateOwner();
            this.OwnerRepository = StructureMapMockRepository.RegisterMock<IRepository<Badge,string>>();
            this.OwnerRepository.Expect(x => x.GetBy(n=>n.Nbr == OwnerThatLogsIn.Badges[0].Nbr)).IgnoreArguments()
                .Return(this.OwnerThatLogsIn.Badges[0]);
            this.SecurityServiceMocked = MockRepository.GenerateMock<ISecurityService>();
            this.Password = "NotHashedPassword";
            
            this.SecurityServiceMocked.Expect(n => n.Hash(this.Password, this.OwnerThatLogsIn.PasswordSalt))
                .Return(this.OwnerThatLogsIn.PasswordHash);
            this.Subject = new AuthenticationService(this.OwnerRepository, this.SecurityServiceMocked);
        }

        public override void When()
        {
            this.Result = this.Subject.Authenticate(OwnerThatLogsIn.Badges[0].Nbr, this.Password, out this.OwnerId);
        }

        [TestMethod]
        public void ThenPasswordHashed()
        {
            this.SecurityServiceMocked.AssertWasCalled(n => n.Hash(this.Password, this.OwnerThatLogsIn.PasswordSalt));
        }

        [TestMethod]
        public void ThenAuthenticate()
        {
            Assert.IsTrue(this.Result);   
        }
    }
}
