using System.Collections.Generic;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Application;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BackToOwner.Golf.Web.Test.UnitTests
{
    [TestClass]
    public class GivenTenantContextAndServiceConfigured : Specification
    {
        protected IRepository<Badge, string > MockedBadgeRepository;
        protected IRepository<Declaration> MockedDeclarationRepository;
        protected IRepository<Owner> MockedOwnerRepository; 
        protected IMapperService MockedMapperService;
        protected ISessionService MockedSessionService;
        protected ISecurityService MockedSecurityService;
        protected IAuthenticationService MockedAutheticationService;
        protected IDistributorService MockedDistributorService;
        protected ISmsService MockedSmsService;
        protected IMailService MockedMailService;
        protected IResourceProvider StubResourceProvider;
        protected IMailFactory MockedMailFactory;
        protected Dictionary<string, string> Resources;
        protected ApplicationFacade ApplicationFacade;

        public override void Given()
        {
            base.Given();
            this.StubResourceProvider = MockRepository.GenerateMock<IResourceProvider>();
            this.Resources = DomainStubFactory.CreateResources();
            this.StubResourceProvider.Stub(n => n.GetResources()).Return(this.Resources);
            TenantContext.SetTenantContextProvider(new StubTenantContextProvider());
            TenantResources.SetTenantResourceProvider(this.StubResourceProvider);

            this.MockedBadgeRepository = MockRepository.GenerateMock<IRepository<Badge,string>>();
            this.MockedDeclarationRepository = MockRepository.GenerateMock<IRepository<Declaration>>();
            this.MockedMapperService = MockRepository.GenerateMock<IMapperService>();
            this.MockedSessionService = MockRepository.GenerateMock<ISessionService>();
            this.MockedSecurityService = MockRepository.GenerateMock<ISecurityService>();
            this.MockedDistributorService = MockRepository.GenerateMock<IDistributorService>();
            this.MockedSmsService = StructureMapMockRepository.RegisterMock<ISmsService>();
            this.MockedMailService = StructureMapMockRepository.RegisterMock<IMailService>();
            this.MockedAutheticationService = StructureMapMockRepository.RegisterMock<IAuthenticationService>();
            this.MockedMailFactory = StructureMapMockRepository.RegisterMock<IMailFactory>();
            this.MockedOwnerRepository = StructureMapMockRepository.RegisterMock<IRepository<Owner>>();

            this.ApplicationFacade = new ApplicationFacade(this.MockedSessionService,this.MockedDistributorService,this.MockedBadgeRepository,this.MockedDeclarationRepository,this.MockedSecurityService, this.MockedAutheticationService,this.MockedOwnerRepository,this.MockedMapperService);
        }
    }
}