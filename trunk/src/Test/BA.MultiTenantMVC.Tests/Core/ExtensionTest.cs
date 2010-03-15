using BA.MultiMVC.Framework.Core;
using NUnit.Framework;

namespace BA.MultiTenantMVC.Framework.UnitTests.Core 
{
    [TestFixture]
    public class ExtensionTest
    {
        
        [Test]
        public void GetBinDirectories_FromExtensionPath_Count2Dirs()
        {
            //Arrenge
            var subject = new Extensions(Configuration.ExtensionPath);
            //Act
            var result = subject.GetBinDirectories();
            //Assert
            Assert.AreEqual(2, result.Count);
        }

        
    }
}