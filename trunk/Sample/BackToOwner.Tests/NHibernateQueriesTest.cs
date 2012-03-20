using System.Collections.Generic;
using System.Linq;
using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;


namespace BackToOwner.Golf.Web.Test
{
    [TestClass]
    public class NHibernateQueriesTest
    {
        private ITransaction trx;
        private ISession _session;
        
        private string testLabel = "testLabel";

        [TestInitialize]
        public void TestInit()
        {
            NHHelper.NHMappingFileRootAssemblyName = "BackToOwner.Golf.Web";
            _session = Queries.OpenSession();
            trx = _session.BeginTransaction();
        }

        [TestCleanup]
        public void CleanUp()
        {
            trx.Rollback();
        }


        [TestMethod]
        public void CanCreateOwner()
        {
            //Act
            _session.Save(
                DomainStubFactory.CreateOwner()
                );

            //Assert
            var memOwner = DomainStubFactory.CreateOwner();
            IQueryable<Owner> expected = Queries.RetrieveOwner(this._session,memOwner);

            var ow = expected.First();
            Assert.AreEqual(ow.EmailAddresses.First(), memOwner.EmailAddresses.First());
        }


        public void CanDeleteOwner()
        {
            //Arrange
            var owner = DomainStubFactory.CreateOwner();
            _session.Save(owner);

            //Act
            _session.Delete(owner);

            var memOwner = DomainStubFactory.CreateOwner();
            IQueryable<Owner> expected = Queries.RetrieveOwner(this._session, memOwner);

            var ow = expected.FirstOrDefault();
            Assert.IsNull(ow);
        }

        [TestMethod]
        public void CanAddMobileToOwner()
        {
            var owner = DomainStubFactory.CreateOwner();
            owner.Mobiles.Add(2,"0495678990");
            //Act
            _session.Save(
                owner
                );

            //Assert
            var result = Queries.RetrieveOwner(this._session,DomainStubFactory.CreateOwner()).First();
            Assert.AreEqual(3, result.Mobiles.Count);
        }

        [TestMethod]
        public void CanEditOwnerMobile()
        {
            string newMobile = "04939292929";
            var owner = DomainStubFactory.CreateOwner();
            owner.Mobiles[0] = newMobile;
            //Act
            _session.Save(
                owner
                );

            //Assert
            var result = Queries.RetrieveOwner(this._session, DomainStubFactory.CreateOwner()).First();
            Assert.AreEqual(newMobile, result.Mobiles[0]);
        }

       


        [TestMethod]
        public void CanAddBadgeToOwner()
        {
            //Act
            var owner = DomainStubFactory.CreateOwner();
            owner.AddBadge(new Badge()
                                {
                                    Nbr = "GHJ-IOP-123"
                                    
                                });
            _session.Save(
                owner
                );


            //Assert
            var result = Queries.RetrieveOwner(this._session, owner);
            Assert.AreEqual(3,result.First().Badges.Count());
            Assert.AreEqual("GHJIOP123", new List<Badge>(result.First().Badges)[2].Nbr);
        }

       

        [TestMethod]
        public void CanSaveRessourcesTest()
        {
            //Act
            _session.Save(
                new Resource()
                    {
                        Label = testLabel,
                        Language ="fr",
                        Value = "fkjl fdldssj kldffkdsl fdkljfd sdf"
                    }
                );


            //Assert
            var expected = _session.QueryOver<Resource>()
                .Where(n => (n.Label == testLabel && n.Language == "fr"))
                .Select(n => n.Value);
                
            Assert.IsTrue(expected.RowCount()>0);
        }

        [TestMethod]
        public void CanGetRessourcesTest()
        {
            //Assert
            var expected = _session.QueryOver<Resource>()
                .List<Resource>();
            Assert.IsTrue(expected.Count>0);
        }



    }
}
