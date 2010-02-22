using System;
using System.Diagnostics;
using BA.MultiMVC.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using BA.MultiMVC.Sample;
using BA.MultiMVC.Sample.Extensions.Contoso.Controllers;

namespace BA.MultiMVC.Tests
{
    /// <summary>
    /// Summary description for StructureMapTester
    /// </summary>
    [TestClass]
    public class StructureMapConfigurationTest
    {
        #region Methods

       
        [TestInitialize]
        public void Initialize()
        {
            Bootstrapper.ConfigureStructureMap();
            
        }

        [TestMethod]
        public void What_do_we_have()
        {
            Debug.WriteLine(ObjectFactory.WhatDoIHave());  
        }

        [TestMethod]
        public void ShouldFindContosoHomeController()
        {
            var result = ObjectFactory.GetNamedInstance(typeof(BaseController), "ContosoHome");

            Assert.IsInstanceOfType(result, typeof(ContosoHomeController));
        }

 
        [TestMethod]
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

        [TestMethod]
        public void ScanControllersAndRepositoriesFromPath_WithRootPath_ShouldRegister_AtLeastOneDomainFactory()
        {
            bool check = false;
            foreach (var instance in ObjectFactory.Model.InstancesOf<IRepository>())
            {
                check = true;
                Console.WriteLine(instance.Name + " is " + instance.ConcreteType.Name);
            }
            Assert.IsTrue(check, "Not one Repository was found!");
        }

        [TestMethod]
        public void ScanControllersAndRepositoriesFromPath_WithRootPath_ShouldRegister_AtLeastOneRepository()
        {
            bool check = false;
            foreach (var instance in ObjectFactory.Model.InstancesOf<IRepository>())
            {
                check = true;
                Console.WriteLine(instance.Name + " is " + instance.ConcreteType.Name);
            }
            Assert.IsTrue(check, "Not one Repository was found!");
        }

        #endregion Methods
    }
}