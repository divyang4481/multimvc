
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BA.MultiMVC.Ressources;

namespace BA.MultiMVC.Tests
{
    /// <summary>
    /// Summary description for SaasDistionayTest
    /// </summary>
    [TestClass]
    public class SaasDictionayTest
    {
        #region Methods

        [TestMethod]
        public void CreateDictionary_Add_ShouldAddTheStrings()
        {
            //Arrenge
            var dictionary = new RessourceDictionary {{"FirstKey", "FirstValue"}, {"SecondKey", "SecondValue"}};

            //Act

            //Assert
            Assert.AreEqual(2, dictionary.Count);
            Assert.AreEqual("FirstValue",dictionary["FirstKey"]);
        }

        [TestMethod]
        public void CreateDictionary_ShouldCreateNewDictionary()
        {
            //Act
            var dictionary = new RessourceDictionary();

            //Assert
            Assert.IsNotNull(dictionary);
        }

        #endregion Methods
         
    }
}