using NUnit.Framework;

namespace BA.MultiMvc.Framework.UnitTests.Ressources
{
    [TestFixture]
    public class RessourceProviderServiceTest
    {

        [Test]
        public void GetRessources_CallOn_CacheServiceMock_GetObject()
        {
            //Arrange
            var mockCache = new Moq.Mock<ICacheService>();
            var subject = new ResourceProvider(mockCache.Object);
            subject.Context = new TenantContext("Default","fr");
            mockCache.Expect(c => c.GetObject("ressources"));

            //Act
            subject.GetResources();

            //Assert
            mockCache.Verify();
        }
    }
}

