using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BA.MultiMVC.Core;

namespace BA.MultiMVC.ParametrizedTest
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
            Assert.IsInstanceOfType(result, expectedType);
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
            Assert.IsInstanceOfType(result, expectedType);
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
            Assert.IsInstanceOfType(result, expectedType);
        }

          public void CreateServiceAssertRepositoryIsInstanceOfType(Type requestedType, Type expectedType)
        {
            //Act
            var service = _tenantFactory.CreateService(requestedType);
            Object result=null;
            var properties = service.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.IndexOf("Repository") > -1)
                    result = property.GetValue(service, null);
            }

            //Assert
            Assert.IsInstanceOfType(result, expectedType);
        }
    }
}
