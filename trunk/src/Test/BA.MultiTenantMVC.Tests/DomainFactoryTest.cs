using BA.MultiMVC.ParametrizedTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BA.MultiMVC.Sample;
using BA.MultiMVC.Sample.Extensions.Contoso.Infrastructure;
using BA.MultiMVC.Sample.Models.Infrastructure;
using BA.MultiMVC.Sample.Models.Domain;
using BA.MultiMVC.Sample.Extensions.Domain;
using BA.MVC.MultiTenant.Core;


namespace BA.MultiMVC.Tests
{
    /// <summary>
    /// Summary description for SaasMVCFactory
    /// </summary>
    [TestClass]
    public class DomainFactoryTest
    {

        [TestInitialize]
        public void Initialize()
        {
            Bootstrapper.ConfigureStructureMap();
        }

        [TestMethod]
        public void CreateRepository_ForDefault_IsNotNull()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsNotNull(typeof(IUserRepository));
        }


        [TestMethod]
        public void CreateRepository_ForDefault_IsUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsInstanceOfType(typeof(IUserRepository), typeof(UserRepository));
        }

        [TestMethod]
        public void CreateUserRepository_ForContoso_IsContosoUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateRepositoryAssertIsInstanceOfType(typeof(IUserRepository), typeof(ContosoUserRepository));
        }

        [TestMethod]
        public void CreateService_ForDefault_IsNotNull()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsNotNull(typeof(IMembershipService));
        }

        [TestMethod]
        public void CreateService_ForDefault_IsDefaultMembershipService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsInstanceOfType(typeof(IMembershipService), typeof(MembershipService));
        }

        [TestMethod]
        public void CreateService_ForContoso_IsContosoMembershipService()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertIsInstanceOfType(typeof(IMembershipService), typeof(ContosoMembershipService));
        }

        [TestMethod]
        public void CreateService_ForDefault_RepositoryIsUserRepository()
        {
             //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateServiceAssertRepositoryIsInstanceOfType(
                typeof(IMembershipService), 
                typeof(UserRepository));
        }

        [TestMethod]
        public void CreateService_ForContoso_RepositoryIsContosoUserRepository()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Contoso");
            //Act & Assert
            parametrizedTest.CreateServiceAssertRepositoryIsInstanceOfType(
                typeof(IMembershipService),
                typeof(ContosoUserRepository));
        }

        [TestMethod]
        public void CreateUser_ForDefault_IsUser()
        {
            //Arrenge
            var parametrizedTest = CreateTenantFactoryTest("Default");
            //Act & Assert
            parametrizedTest.CreateModelAssertIsInstanceOfType(typeof(User), typeof(User));
        }

        [TestMethod]
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
                Ressources = null,
                ConnectionString = "dummy"
            };
            var factory = new DomainFactory(context);
            return new TenantFactoryTest(factory);
        }


    }
}
