using System;
using BA.MultiMvc.Framework.Helpers;
using NUnit.Framework;

namespace BA.MultiMvc.Framework.Core.MultiTenantMVC.Test.Util.ParamatrizedTests
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
            var result = _tenantFactory.Create(requestedType);

            //Assert
            Assert.AreEqual(expectedType.FullName,result.GetType().FullName);
        }

        public void CreateRepositoryAssertIsNotNull(Type requestedType)
        {
            //Act
            var result = _tenantFactory.Create(requestedType);

            //Assert
            Assert.IsNotNull(result);
        }

        public void CreateServiceAssertIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var result = _tenantFactory.Create(requestedType);

            //Assert
            Assert.AreEqual(expectedType.FullName, result.GetType().FullName);
        }

        public void CreateServiceAssertIsNotNull(Type requestedType)
        {
            //Act
            var result = _tenantFactory.Create(requestedType);

            //Assert
            Assert.IsNotNull(result);
        }

        public void CreateModelAssertIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var result = _tenantFactory.Create(requestedType);

            //Assert
            Assert.AreEqual(expectedType.FullName, result.GetType().FullName);
        }

        public void CreateServiceAssertRepositoryIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var service = _tenantFactory.Create(requestedType);
            var repositoryProperties = service.FindProperties(typeof(ITenantModel));
            var result = repositoryProperties[0].GetValue(service, null);

            //Assert
            Assert.AreEqual(expectedType.FullName, result.GetType().FullName);
        }

        public void CreateServiceAssertContextIsNotNull(Type requestedType)
        {
            //Act
            var service = _tenantFactory.Create(requestedType);
            var subject = service.Context;
            //Assert
            Assert.IsNotNull(subject);
        }

        public void CreateServiceAssertContextIsNotNullOnServiceProperties(Type requestedType)
        {
            //Act
            var service = _tenantFactory.Create(requestedType);
            AssertContextIsNotNullOnServiceProperties(service);
        }

        private void AssertContextIsNotNullOnServiceProperties(ITenantModel service)
        {
            var serviceProperties = service.FindProperties(typeof(ITenantModel));
            //Assert
            foreach (var property in serviceProperties)
            {
                var val = (ITenantModel)property.GetValue(service, null);
                Assert.IsNotNull(val.Context);
                AssertContextIsNotNullOnServiceProperties(val);
            }
        }
    }
}