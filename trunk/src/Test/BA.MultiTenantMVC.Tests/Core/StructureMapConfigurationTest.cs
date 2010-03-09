using System;
using System.Diagnostics;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Extensions.Contoso.Controllers;
using BA.MultiMVC.Framework.Core;
using NUnit.Framework;
using StructureMap;

namespace BA.MultiTenantMVC.Framework.UnitTests.Core
{
    /// <summary>
    /// Summary description for StructureMapTester
    /// </summary>
    [TestFixture]
    public class StructureMapConfigurationTest
    {
        #region Methods

        [TestFixtureSetUp]
        public void Initialize()
        {
            BootstrapperForTest.ConfigureStructureMap(".");
        }

        [Test]
        public void What_do_we_have()
        {
            Debug.WriteLine(ObjectFactory.WhatDoIHave());  
        }

        [Test]
        public void ShouldFindContosoHomeController()
        {
            var result = ObjectFactory.GetNamedInstance(typeof(BaseController), "ContosoHome");

            Assert.IsInstanceOfType(typeof(ContosoHomeController),result);
        }

 
        [Test]
        public void ScanControllers_WithRootPath_ShouldRegister_AtLeastOneController()
        {
            var check = false;

            foreach (var instance in ObjectFactory.Model.InstancesOf<BaseController>())
            {
                check = true;
                Console.WriteLine(instance.Name + " is " + instance.ConcreteType.Name);
            }
            Assert.IsTrue(check, "Not one Controller was found!");
        }

        [Test]
        public void ScanControllersAndRepositoriesFromPath_WithRootPath_ShouldRegister_AtLeastOneDomainFactory()
        {
            bool check = false;
            foreach (var instance in ObjectFactory.Model.InstancesOf<ITenantModel>())
            {
                check = true;
                Console.WriteLine(instance.Name + " is " + instance.ConcreteType.Name);
            }
            Assert.IsTrue(check, "Not one Repository was found!");
        }

        [Test]
        public void ScanControllersAndRepositoriesFromPath_WithRootPath_ShouldRegister_AtLeastOneRepository()
        {
            bool check = false;
            foreach (var instance in ObjectFactory.Model.InstancesOf<ITenantModel>())
            {
                check = true;
                Console.WriteLine(instance.Name + " is " + instance.ConcreteType.Name);
            }
            Assert.IsTrue(check, "Not one Repository was found!");
        }

        #endregion Methods
    }
}