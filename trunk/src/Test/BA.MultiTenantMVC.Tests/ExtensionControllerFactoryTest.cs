using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BA.MultiMVC.Sample;
using BA.MultiMVC.Test.Util.Stubs;
using BA.MultiMVC.Sample.Controllers;
using BA.MultiMVC.Core;
using BA.MultiMVC.Sample.Extensions.Contoso.Controllers;

namespace BA.MultiMVC.Tests
{
   

    /// <summary>
    /// Summary description for SaasMVCFactory
    /// </summary>
    [TestClass]
    public class ExtensionControllerFactoryTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Bootstrapper.ConfigureStructureMap(".");
        }

        [TestMethod]
        public void GetControllerInstance_ForHomeControllerAndDefaultTenant_ControllerIsInstanceOfTypeHomeController()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Default");
            
            //Assert
            Assert.IsInstanceOfType(result, typeof(HomeController));

        }

        [TestMethod]
        public void GetControllerInstance_ForHomeControllerAndContosoTenant_ControllerIsInstanceOfTypeContosoHomeController()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Contoso");
            
            //Assert
            Assert.IsInstanceOfType(result, typeof(ContosoHomeController));
        }

        [TestMethod]
        public void GetControllerInstance_ForHomeControllerAndContosoTenant_TenantKeyIsContoso()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "contoso");

            //Assert
            Assert.AreEqual("Contoso", ((BaseController)result).TenantContext.TenantKey);
        }

        [TestMethod]
        public void GetControllerInstance_ForHomeControllerAndDefaultTenant_TenantContextIsNotNull()
        {
            var result = ExtensionControllerFactoryCreateInstance(typeof(HomeController), "Default");

            //Assert
            Assert.IsNotNull(((BaseController)result).TenantContext);

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
