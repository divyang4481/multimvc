using BA.MultiMVC.Framework.Core;
using NUnit.Framework;
using BA.MultiMVC.Framework.Caching;

namespace BA.MultiMVC.Framework.IntegrationTests.Caching
{
    [TestFixture]
    public class DefaultCacheServiceTest
    {

        [Test]
        public void Add_WithSameContext_ObjectInCacheShouldBeRetrieved()
        {
            //Arrange
            var subject = new DefaultCacheService() {Context = new TenantContext("testTenant", "fr")};
            var expected = "Expected object";
            subject.Add("mykey", expected);

            //Act
            var result = subject.GetObject("myKey");

            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
