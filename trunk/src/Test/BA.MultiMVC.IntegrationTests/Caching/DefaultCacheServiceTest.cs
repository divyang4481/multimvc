using BA.MultiMVC.Framework.Core;
using NUnit.Framework;
using BA.MultiMVC.Framework.Caching;

namespace BA.MultiMVC.Framework.IntegrationTests.Caching
{
    [TestFixture]
    public class DefaultCacheServiceTest
    {
        const string key = "key";
        const string expected = "Expected object";

        [Test]
        public void Add_WithSameContext_ObjectInCacheShouldBeRetrieved()
        {
            //Arrange
            var subject = addToCache(key, expected);

            //Act
            var result = subject.GetObject(key);

            //Assert
            Assert.AreEqual(expected, result);

        }

        [Test]
        public void Add_WithDifferentTenant_ObjectInCacheShouldNotBeRetrieved()
        {
            //Arrange
            var subject = addToCache(key, expected);

            //Act
            subject.Context = new TenantContext("DifferentTenant", "fr");
            var result = subject.GetObject(key);

            //Assert
            Assert.IsNull(result);

        }

        private static DefaultCacheService addToCache(string key, string expected)
        {
            var subject = new DefaultCacheService() { Context = new TenantContext("testTenant", "fr") };
            subject.Add(key, expected);
            return subject;
        }
    }
}
