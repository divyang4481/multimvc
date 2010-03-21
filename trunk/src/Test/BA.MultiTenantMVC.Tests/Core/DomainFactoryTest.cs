using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Domain;
using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Models.Infrastructure;
using BA.MultiMvc.Framework.Core.MultiTenantMVC.Test.Util.ParamatrizedTests;
using BA.MultiMvc.Framework.Ressources;
using BA.MultiMvc.Sample.Extensions.Contoso.Model.Domain;
using BA.MultiMvc.Sample.Extensions.Contoso.Model.Infrasturcture;
using NUnit.Framework;


namespace BA.MultiTenantMVC.Framework.UnitTests.Core
{
    /// <summary>
    /// Summary description for SaasMVCFactory
    /// </summary>
    [TestFixture]
    public class DomainFactoryTest
    {

        [TestFixtureSetUp]
        public void Initialize()
        {
            BootstrapperForTest.ConfigureStructureMap(".");
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
        public void CreateUserRepository_ForContoso_IsContosoUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsInstanceOfType(typeof(IUserRepository), typeof(ContosoUserRepository));
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
            parametrizedTest.CreateServiceAssertIsInstanceOfType(typeof(IMembershipService), typeof(MembershipService));
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
        public void CreateRessourceProviderService_ForDefault_ContextIsNotNullOnCacheService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertContextIsNotNullOnServiceProperties(typeof(IRessourceProviderService));
        }

        [Test]
        public void CreateRessourceProviderService_ForContoso_ContextIsNotNullOnCacheService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertContextIsNotNullOnServiceProperties(typeof(IRessourceProviderService));
        }
            

        [Test]
        public void CreateService_ForDefault_RepositoryIsUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertRepositoryIsInstanceOfType(
                typeof(IMembershipService), 
                typeof(UserRepository));
        }

        [Test]
        public void CreateService_ForContoso_RepositoryIsContosoUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertRepositoryIsInstanceOfType(
                typeof(IMembershipService),
                typeof(ContosoUserRepository));
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