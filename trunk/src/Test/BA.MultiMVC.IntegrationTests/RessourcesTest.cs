using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using BA.MultiMVC.Framework.Ressources;
using BA.MultiTenantMVC.Sample.Models.Infrastructure;
using NUnit.Framework;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;

namespace BA.MultiMVC.IntegrationTests
{
    [TestFixture]
    public class RessourcesTest
    {
        private TransactionScope _scope;
        private DBDataContext _db;
        private Ressource _ressource;
        private const string RessourceKeyString = "Test.SampleRessource";
        private const string RessourceValueString = "Hello from test!";
        private const string Language = "en";

        [SetUp]
        public void Init()
        {
            _scope = new TransactionScope();
            _db = new DBDataContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            _ressource = new Ressource()
                             {
                                 RessourceKey = RessourceKeyString, 
                                 RessourceValue = RessourceValueString
                             };
            _db.Ressources.InsertOnSubmit(_ressource);
        }

        [Test]
        public void RessourceServiceProvider_GetRessourceDictionary_ContainsTestRessource()
        {
            //Arrange
            var ressourceRepository = new RessourceRepository(_db);
            IRessourceProviderService subject = new RessourceProviderService(ressourceRepository);

            //Act
            IDictionary<string,string> result = subject.GetRessources(Language);

            //Assert
            Assert.AreEqual(result[RessourceKeyString],RessourceValueString);

        }

        [TearDown]
        public void TearDown()
        {
            _scope.Dispose();
        }
    }

   

   


   

}


