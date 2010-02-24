using BA.MultiMVC.Framework.Ressources;
using NUnit.Framework;

namespace BA.MultiMVC.Framework.Core.MultiTenantMVC.UnitTests
{
    [TestFixture]
    public class RessourcesTest
    {

        [Test]
        public void Ressources_Key_ReturnValue()
        {
            //Arrange
            var subject = new RessourceDictionary();
            subject.Add("AKey", "AValue");

            //Act
            var result = subject["AKey"];

            //Assert
            Assert.AreEqual(result, "AValue");
        }

    }
}