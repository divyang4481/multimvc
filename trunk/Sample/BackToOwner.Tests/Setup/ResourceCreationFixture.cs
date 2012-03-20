using System.Linq;
using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;
using BackToOwner.Web.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Linq;

namespace BackToOwner.Golf.Web.Test.Setup
{
    [TestClass]
    public class ResourceCreationFixture
    {
        private static ISession _currentSession;
        private static ITransaction _tx;

        [TestInitialize]   
        public void Init()
        {
            _currentSession = NHHelper.GetSessionFactoryFor("Default").OpenSession();
            _tx = _currentSession.BeginTransaction();
            _currentSession.CreateQuery("DELETE FROM Resource").ExecuteUpdate();
            DefaultResourceCreation resourceCreation = new DefaultResourceCreation(_currentSession);
            resourceCreation.InsertOrUpdate();
            //currentSession.Flush();

        }

        [TestMethod]
        public void CanFillTableResource()
        {
            var query = from r in _currentSession.Query<Resource>()
                        select r;
            Assert.IsTrue(query.Count()>0);
            
        }

        [TestCleanup]
        public void Cleanup()
        {
            _tx.Dispose();
        }
    }


}
