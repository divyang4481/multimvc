using System;
using System.Diagnostics;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample;
using BA.MultiMvc.Sample.Extensions.Contoso.Controllers;
using NUnit.Framework;
using StructureMap;

namespace BA.MultiMvc.Framework.UnitTests.Core
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
            Bootstrapper.ConfigureStructureMap(".");
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

            Assert.AreEqual(typeof(ContosoHomeController).FullName , result.GetType().FullName);
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