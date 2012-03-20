using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace BackToOwner.Golf.Web.Test
{
    [TestClass]
    public class NHibernateConfigurationTest
    {
        [TestMethod]
        public void CanConfigureNHibernateTest()
        {
            var sessionFactory = NHHelper.GetSessionFactoryFor("Default");
        }

        [TestMethod]
        public void CanWriteSchemaTest()
        {
            NHHelper.CreateShemaExportFile("BackToOwnerDBCreate.sql", "Default");
        }

        [TestMethod]
        public void CanGetSessioFactoryForTenant()
        {
            // Act
            ISessionFactory  sessionFactory = NHHelper.GetSessionFactoryFor("Default");
            
            // Assert
            ISession session= sessionFactory.OpenSession();
            var resources = session.QueryOver<Resource>().List();
            Assert.IsNotNull(resources);
        }
    }
}
