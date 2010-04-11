using System;
using BA.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Extensions.Contoso.Controllers;
using BA.MultiMvc.Test.Util.Stubs;
using NUnit.Framework;

namespace BA.MultiMvc.Framework.UnitTests.Core
{
    /// <summary>
    /// Summary description for SaasMvcFactory
    /// </summary>
    [TestFixture]
    public class ExtensionControllerFactoryTest
    {
        [TestFixtureSetUp]
        public void Initialize()
        {
            BootstrapperForUnitTest.ConfigureStructureMap(".");
        }

        [Test]
        public void GetControllerInstance_ForHomeControllerAndDefaultTenant_ControllerIsInstanceOfTypeHomeController()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Default");
            
            //Assert
            Assert.AreEqual(typeof(HomeController).FullName, result.GetType().FullName);

        }

        [Test]
        public void GetControllerInstance_ForHomeControllerAndContosoTenant_ControllerIsInstanceOfTypeContosoHomeController()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Contoso");
            
            //Assert
            Assert.AreEqual(typeof(ContosoHomeController).FullName, result.GetType().FullName);
        }

        [Test]
        public void GetControllerInstance_ForHomeControllerAndContosoTenant_TenantKeyIsContoso()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "contoso");

            //Assert
            Assert.AreEqual("Contoso", ((BaseController)result).Context.TenantKey);
        }

        [Test]
        public void GetControllerInstance_ForHomeControllerAndDefaultTenant_TenantContextIsNotNull()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Default");

            //Assert
            Assert.IsNotNull(((BaseController)result).Context);

        }

        [Test]
        public void GetControllerInstance_ForHomeControllerAndDefaultTenant_RessourcesIsNotNull()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Default");

            //Assert
            Assert.IsNotNull(((BaseController)result).Resources);

        }

        private static System.Web.Mvc.IController ExtensionControllerFactoryCreateInstance(Type controllerType, string tenantKey)
        {
            //Arrange
            var subject = new ExtensionControllerFactoryForTest();
            subject.TenantKey = tenantKey;

            //Act
            var result = subject.GetControllerInstanceInvoker(controllerType);
            return result;
        }
        
    }
}