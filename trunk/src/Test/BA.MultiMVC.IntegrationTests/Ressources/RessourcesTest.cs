using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using BA.MultiMvc.Framework.IntegrationTests.Specialized;
using BA.MultiMvc.Framework.Ressources;
using BA.MultiTenantMVC.Sample.Models.Infrastructure;
using NUnit.Framework;
using BA.MultiTenantMVC.Sample.Models.Infrastructure.Linq;
using BA.MultiMvc.Framework.Core;
using BA.MultiMvc.Framework.IntegrationTests.Stubs;

namespace BA.MultiMvc.IntegrationTests
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
                                 RessourceValue = RessourceValueString,
                                 RessourceLanguage = Language
                             };
            _db.Ressources.InsertOnSubmit(_ressource);
            _db.SubmitChanges();
        }

        [Test]
        public void RessourceServiceProvider_GetRessourceDictionary_ContainsTestRessource()
        {
            //Arrange
            var ressourceRepository = new RessourceRepositoryForTest(_db);
            var subject = new RessourceProviderService(ressourceRepository,new StubCacheService());
            subject.Context = new TenantContext("Default", Language);

            //Act
            var result = subject.GetRessources();

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


