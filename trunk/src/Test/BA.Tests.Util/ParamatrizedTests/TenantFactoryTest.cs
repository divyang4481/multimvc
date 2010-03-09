using System;
using System.Collections.Generic;
using System.Reflection;
using BA.MultiMVC.Framework.Core;
using BA.MultiMVC.Framework.Helpers;
using NUnit.Framework;

namespace BA.MultiMVC.Framework.Core.MultiTenantMVC.Test.Util.ParamatrizedTests
{
    public class TenantFactoryTest
    {
        TenantFactory _tenantFactory;
        public TenantFactoryTest(TenantFactory tenantFactory)
        {
            _tenantFactory = tenantFactory;
        }

        public void CreateRepositoryAssertIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var result = _tenantFactory.CreateRepository(requestedType);

            //Assert
            Assert.IsInstanceOfType(expectedType,result);
        }

        public void CreateRepositoryAssertIsNotNull(Type requestedType)
        {
            //Act
            var result = _tenantFactory.CreateRepository(requestedType);

            //Assert
            Assert.IsNotNull(result);
        }

        public void CreateServiceAssertIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var result = _tenantFactory.CreateService(requestedType);

            //Assert
            Assert.IsInstanceOfType(expectedType ,result);
        }

        public void CreateServiceAssertIsNotNull(Type requestedType)
        {
            //Act
            var result = _tenantFactory.CreateService(requestedType);

            //Assert
            Assert.IsNotNull(result);
        }

        public void CreateModelAssertIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var result = _tenantFactory.CreateModel(requestedType);

            //Assert
            Assert.IsInstanceOfType(expectedType, result);
        }

        public void CreateServiceAssertRepositoryIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var service = _tenantFactory.CreateService(requestedType);
            var repositoryProperties = service.FindProperties(typeof(IRepository));
            var result = repositoryProperties[0].GetValue(service, null);

            //Assert
            Assert.IsInstanceOfType(expectedType,result);
        }

        public void CreateServiceAssertContextIsNotNull(Type requestedType)
        {
            //Act
            var service = _tenantFactory.CreateService(requestedType);
            var subject = service.Context;
            //Assert
            Assert.IsNotNull(subject);
        }

        public void CreateServiceAssertContextIsNotNullOnServiceProperties(Type requestedType)
        {
            //Act
            var service = _tenantFactory.CreateService(requestedType);
            AssertContextIsNotNullOnServiceProperties(service);
        }

        private void AssertContextIsNotNullOnServiceProperties(IService service)
        {
            var serviceProperties = service.FindProperties(typeof(IService));
            //Assert
            foreach (var property in serviceProperties)
            {
                var val = (IService)property.GetValue(service, null);
                Assert.IsNotNull(val.Context);
                AssertContextIsNotNullOnServiceProperties(val);
            }
        }
    }
}