using BA.MultiMvc.Framework;
using BA.MultiMVC.Framework.NHibernate;
using BA.MultiMvc.Framework.NHibernate;
using BackToOwner.Golf.Web.Infrastructure;
using BackToOwner.Golf.Web.Test.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Context;
using Resource = BackToOwner.Golf.Web.Models.Resource;

namespace BackToOwner.Golf.Web.Test.Controllers
{
    [TestClass]
    public class TenantResourcesTest
    {
        private ISession currentSession;
        private Resource testResource;
        private ITransaction tx;



        [TestInitialize]
        public void Init()
        {
            TenantContext.SetTenantContextProvider(new StubTenantContextProvider());
            TenantResources.SetTenantResourceProvider(new NHCachedResourceProvider(new DefaultCacheService()));
            
            testResource = new Resource()
            {
                Label = "testResource",
                Value = "value for test resource",
                Language = TenantContext.Language
            };
            NHHelper.IsWeb = false;
            NHHelper.ClearCache();
            currentSession = NHHelper.GetSessionFactoryFor("Default").OpenSession();

            CurrentSessionContext.Bind(currentSession);
            tx = currentSession.BeginTransaction();
            currentSession.Save(
                testResource
                );
        }

        [TestCleanup]
        public void Cleanup()
        {
            tx.Dispose();
            currentSession.Close();
        }

        [TestMethod]
        public void CanGetResources()
        {
            Assert.IsNotNull(TenantResources.Values[testResource.Label]);
        }

    }
}
