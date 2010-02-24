using NUnit.Framework;

namespace BA.MultiTenantMVC.UnitTests
{
    [TestFixture]
    public class RessourcesTest
    {

        [Test]
        public void Ressources_Key_ReturnValue()
        {
            //Arrange
            var subject = new MultiMVC.Ressources.RessourceDictionary();
            subject.Add("AKey", "AValue");

            //Act
            var result = subject["AKey"];

            //Assert
            Assert.AreEqual(result, "AValue");
        }

    }
}