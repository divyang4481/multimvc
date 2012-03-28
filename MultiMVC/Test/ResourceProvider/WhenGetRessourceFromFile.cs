using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using BA.MultiMvc.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace BA.MultiMvc.Test
{
    [TestClass]
    public class WhenGetRessourceFromFile:GivenResourcesToSerialize
    {
        private IDictionary<string, string> Result; 
        private FileResourceProvider fileRessourceProvider;
        public override void Given()
        {
            base.Given();
            var tenantContextProvider = MockRepository.GenerateMock<ITenantContextProvider>();
            tenantContextProvider.Stub(n => n.Language).Return("fr");
            TenantContext.SetTenantContextProvider(tenantContextProvider);

            XmlSerializer serializer = new XmlSerializer(typeof(List<FileResourceProvider.RessourceDictionaryItem>));
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, ResourcesToSerialize);
                stream.Close();
            };
            fileRessourceProvider = new FileResourceProvider();
        }

        public override void When()
        {
            base.When();
            this.Result = fileRessourceProvider.GetResources();

        }

        [TestMethod]
        public void ThenResltIsNotEmpty()
        {
            Assert.IsTrue(this.Result.Count>0);
        }
    }
}
