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
            var mockRepository = new Moq.Mock<IResourceRepository>();
            var mockCache = new Moq.Mock<ICacheService>();
            var subject = new ResourceProviderService(mockRepository.Object, mockCache.Object);
            subject.Context = new TenantContext("Default","fr");
            mockCache.Expect(c => c.GetObject("ressources"));

            //Act
            subject.LoadResources();

            //Assert
            mockCache.Verify();
        }
    }
}

