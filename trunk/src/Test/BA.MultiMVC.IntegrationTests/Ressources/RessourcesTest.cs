using System.Configuration;
using System.Transactions;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Framework.IntegrationTests.Specialized;
using BA.MultiMvc.Sample.Models.Infrastructure.Linq;
using NUnit.Framework;
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
            var subject = new ResourceProviderService(ressourceRepository,new StubCacheService());
            subject.Context = new TenantContext("Default", Language);

            //Act
            var result = subject.LoadResources();

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


