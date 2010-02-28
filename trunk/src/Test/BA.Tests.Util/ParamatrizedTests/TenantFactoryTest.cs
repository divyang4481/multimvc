using System;
using BA.MultiMVC.Framework.Core;
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
            Object result=null;
            var properties = service.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.IndexOf("Repository") > -1)
                    result = property.GetValue(service, null);
            }

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
    }
}