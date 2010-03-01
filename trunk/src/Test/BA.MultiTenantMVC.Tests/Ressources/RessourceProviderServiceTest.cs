using BA.MultiMVC.Framework.Caching;
using BA.MultiMVC.Framework.Core;
using BA.MultiMVC.Framework.Ressources;
using NUnit.Framework;

namespace BA.MultiTenantMVC.Framework.UnitTests.Ressources
{
    [TestFixture]
    public class RessourceProviderServiceTest
    {

        [Test]
        public void GetRessources_CallOn_CacheServiceMock_GetObject()
        {
            //Arrange
            var mockRepository = new Moq.Mock<IRessourceRepository>();
            var mockCache = new Moq.Mock<ICacheService>();
            var subject = new RessourceProviderService(mockRepository.Object, mockCache.Object);
            subject.Context = new TenantContext("Default","fr");

            //Act
            subject.GetRessources();

            //Assert
            mockCache.Verify(c=>c.GetObject("ressources"));
        }
    }
}

