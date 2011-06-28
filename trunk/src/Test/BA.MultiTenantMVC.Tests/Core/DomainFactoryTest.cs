using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMvc.Test.Util.ParamatrizedTests;
using BA.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Extensions.Contoso.Model.Domain;
using BA.MultiMvc.Sample.Extensions.Contoso.Model.Infrasturcture;
using BA.MultiMvc.Sample.Models.Infrastructure;
using NUnit.Framework;


namespace BA.MultiMvc.Framework.UnitTests.Core
{
    /// <summary>
    /// Summary description for SaasMvcFactory
    /// </summary>
    [TestFixture]
    public class DomainFactoryTest
    {

        [TestFixtureSetUp]
        public void Initialize()
        {
            BootstrapperForUnitTest.ConfigureStructureMap(".");
        }

        [Test]
        public void CreateRepository_ForDefault_IsNotNull()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsNotNull(typeof(IUserRepository));
        }


        [Test]
        public void CreateRepository_ForDefault_IsUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsInstanceOfType(typeof(IUserRepository), typeof(UserRepository));
        }

     

        [Test]
        public void CreateService_ForDefault_IsNotNull()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsNotNull(typeof(IMembershipService));
        }

        [Test]
        public void CreateService_ForDefault_IsDefaultMembershipService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsInstanceOfType(typeof(IMembershipService), typeof(AccountMembershipService));
        }

        [Test]
        public void CreateService_ForContoso_IsContosoMembershipService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsInstanceOfType(typeof(IMembershipService), typeof(ContosoMembershipService));
        }

        [Test]
        public void CreateService_ForDefault_ContextIsNotNull()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertContextIsNotNull(typeof(IMembershipService));
        }

        [Test]
        public void CreateRessourceProviderService_ForDefault_ContextIsNotNullOnResourceProvider()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertContextIsNotNullOnServiceProperties(typeof(IResourceProvider));
        }

        [Test]
        public void CreateRessourceProviderService_ForContoso_ContextIsNotNullResourceProvider()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertContextIsNotNullOnServiceProperties(typeof(IResourceProvider));
        }
            

        [Test]
        public void CreateService_ForContoso_RepositoryIsUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertRepositoryIsInstanceOfType(
                typeof(IMembershipService), 
                typeof(UserRepository));
        }

      

        [Test]
        public void CreateUser_ForDefault_IsUser()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateModelAssertIsInstanceOfType(typeof(User), typeof(User));
        }

        [Test]
        public void CreateUser_ForContoso_IsContosoUser()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateModelAssertIsInstanceOfType(typeof(User), typeof(ContosoUser));
        }


        private TenantFactoryTest CreateTenantFactoryTest(string tenantKey)
        {
            var context = new TenantContext(tenantKey,"en")
                              {
                                  TenantKey = tenantKey,
                                  Language = "en",
                                  ConnectionString = "dummy"
                              };
            var factory = new DomainFactory(context);
            return new TenantFactoryTest(factory);
        }


    }
}